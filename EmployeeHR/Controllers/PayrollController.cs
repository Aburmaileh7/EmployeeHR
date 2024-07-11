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
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PayrollModel payroll)
        {
            if (payroll != null) 
            { 
                _dbContext.Payrolls.Add(payroll);   
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
