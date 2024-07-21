using EmployeeHR.Data;
using EmployeeHR.Models;
using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Controllers
{
    public class PayrollController : Controller
    {
        private readonly HRDBContext _dbContext;
        public PayrollController(HRDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //var model = _dbContext.Payrolls.Include(x => x.Employee).ToList();
            var viewmodel = _dbContext.Payrolls.Include(x => x.Employee).Select(x => new PayrollViewModel
            {
                Id = x.Id,
                PayrollDate = x.PayrollDate,
                Bonus = x.Bonus,
                SocialSecurityAmount = x.SocialSecurityAmount,
                CreatedBy = x.CreatedBy,
                EmployeeFullName = $"{x.Employee.FirstName} {x.Employee.LastName}",
                NetSalary=x.NetSalary
            }).ToList();

            return View(viewmodel);
        }



        public ActionResult Create()
        {
            ViewBag.EmployeeList = _dbContext.Employees.Select(x => new
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
            }).ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create(PayrollViewModel payrollViewModel)
        {
            if (payrollViewModel != null)
            {
                var payroll = new PayrollModel();
                payroll.NetSalary = SalaryCalaulation(payrollViewModel);
                if (payroll.NetSalary == 0)
                {
                    return View();
                }

                payroll.PayrollDate = payrollViewModel.PayrollDate;
                payroll.EmployeeId = payrollViewModel.EmployeeId;
                payroll.Bonus = payrollViewModel.Bonus;
                payroll.SocialSecurityAmount = payrollViewModel.SocialSecurityAmount;
                payroll.Leaves = payrollViewModel.Leaves;


                payroll.TS = DateTime.Now;
                payroll.CreatedBy = "Logged User";

                _dbContext.Payrolls.Add(payroll);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult EmployeePayrolls(int id)
        {
            var model = _dbContext.Employees
                .Include(x => x.Department)
                .Include(x => x.Payrolls)
                .Where(x => x.Id == id).ToList();

            var payroll = new PayrollModel();
            model.FirstOrDefault().Payrolls.Add(payroll);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeList = _dbContext.Employees.Select(x => new
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
            }).ToList();
            //var model = _dbContext.Payrolls.FirstOrDefault(x => x.Id == id);

            var viewmodel = _dbContext.Payrolls.Include(x => x.Employee).Select(x => new PayrollViewModel
            {
                Id = x.Id,
                PayrollDate = x.PayrollDate,
                Bonus = x.Bonus,
                SocialSecurityAmount = x.SocialSecurityAmount,
                CreatedBy = x.CreatedBy,
                EmployeeFullName = $"{x.Employee.FirstName} {x.Employee.LastName}",
                NetSalary = x.NetSalary,
                Leaves=x.Leaves,
                BasicSalary=x.Employee.BasicSalary
            }).FirstOrDefault(x=> x.Id ==id);

            return View("Create", viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(int id, PayrollViewModel payroll)
        {

            var model = _dbContext.Payrolls.FirstOrDefault(x => x.Id == id);

            if (model!= null)
            {
                model.EmployeeId = payroll.EmployeeId;
                model.PayrollDate = payroll.PayrollDate;
                model.Bonus = payroll.Bonus;
                model.Leaves = payroll.Leaves;
                model.SocialSecurityAmount = payroll.SocialSecurityAmount;
                model.TS = DateTime.Now;
                model.NetSalary = SalaryCalaulation(payroll);
               

            }

            _dbContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        private decimal SalaryCalaulation(PayrollViewModel payroll)
        {
            decimal netSalary = 0;

            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == payroll.EmployeeId);
            if (employee != null)
            {
                var leavesAmount = (employee?.BasicSalary / 30 / 8) * Convert.ToDecimal(payroll.Leaves);
                netSalary = employee.BasicSalary + payroll.Bonus - payroll.SocialSecurityAmount - Convert.ToDecimal(leavesAmount);
            }
            else
            {
                netSalary = 0;
            }
            return netSalary;
        }


        [HttpGet]
        public IActionResult GetBasicSalary(int employeeId)
        {
            try
            {
            var basicSalary = _dbContext.Employees.FirstOrDefault(x => x.Id == employeeId).BasicSalary;
             return Ok(basicSalary);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


    }
}
