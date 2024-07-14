using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Controllers
{
    public class PayrollController : Controller
    {
        private readonly HRDbContext _dbContext;
        public PayrollController(HRDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Payrolls.Include(x =>x.Employee).ToList();
            return View(model);
        }


        public ActionResult Create()
        {  ViewBag.EmployeeList = _dbContext.Employees.Select(x=> new
            {
                Id=x.Id,
                Name=x.FirstName + " " + x.LastName,
            }).ToList();
          

            return View();
        }

        [HttpPost]
        public ActionResult Create(PayrollModel payroll)
        {
            if (payroll != null) 
            {
                payroll.NetSalary = SalaryCalaulation(payroll);

                if (payroll.NetSalary== 0)
                {
                    return View();
                }

                payroll.TS = DateTime.Now;
                payroll.CreatedBy = "Logged User";

                _dbContext.Payrolls.Add(payroll);   
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeList = _dbContext.Employees.Select(x => new
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
            }).ToList();
            var model = _dbContext.Payrolls.FirstOrDefault(x => x.Id == id);

            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(int id,PayrollModel payroll)
        {
            payroll.NetSalary= SalaryCalaulation(payroll);
            payroll.TS= DateTime.Now;

            _dbContext.Payrolls.Update(payroll);
            _dbContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
        

        private decimal SalaryCalaulation(PayrollModel payroll)
        {
            decimal netSalary = 0;

            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == payroll.EmployeeId);
            if (employee != null)
            {
                var leavesAmount = (employee?.BasicSalary / 30 / 8) * Convert.ToDecimal(payroll.Leaves);
                netSalary = employee.BasicSalary+payroll.Bonus-payroll.SSa-Convert.ToDecimal(leavesAmount);
            }
            else
            {
                netSalary = 0;
            }
            return netSalary;
        }
    }
}
