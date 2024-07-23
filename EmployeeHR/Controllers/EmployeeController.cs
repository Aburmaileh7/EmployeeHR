using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EmployeeHR.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeModel GetEmployee(int id)
        {
            var model = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return new EmployeeModel();
            }
        }


        //database/////////////////////
        private readonly HRDBContext _dbContext;

        public EmployeeController(HRDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var employees = _dbContext.Employees.Include(x => x.Department)
                                                .OrderBy(x => x.FirstName).ToList();
                                                

            return View(employees);
        }

        //get Details

        public ActionResult Details(int id)
        {
            var EmployeeDepartmentModel = (from emp in _dbContext.Employees
                                           join dep in _dbContext.Departments on emp.DepartmentId equals dep.Id
                                           select new EmployeeModel
                                           {

                                               Id = emp.Id,
                                               FirstName = emp.FirstName,
                                               LastName = emp.LastName,
                                               HiringDate = emp.HiringDate,
                                               DOB = emp.DOB,
                                               IsActive = emp.IsActive,
                                               BasicSalary = emp.BasicSalary,
                                               Email = emp.Email,
                                               DepartmentId = emp.DepartmentId,
                                               Department = dep
                                           }).FirstOrDefault(x => x.Id == id);
            return View(EmployeeDepartmentModel);
        }


        //get Create 

        public ActionResult Create()
        {
            ViewBag.DepartmentsList = _dbContext.Departments;

            return View();
        }



        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            if(employee !=null )
            {
               _dbContext.Employees.Add(employee);
               _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DepartmentList = _dbContext.Departments;
            var employeemodel = _dbContext.Employees.FirstOrDefault(x => x.Id==id);
            if(employeemodel != null)
            {
                return View("Create", employeemodel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
 
        public ActionResult Edit(int id,EmployeeModel employee)
        {

            var employeemodel = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employeemodel != null)
            {

                employeemodel.Id = employee.Id;
                employeemodel.FirstName = employee.FirstName;
                employeemodel.LastName = employee.LastName;
                employeemodel.HiringDate = employee.HiringDate;
                employeemodel.DOB = employee.DOB;
                employeemodel.BasicSalary = employee.BasicSalary;
                employeemodel.IsActive = employee.IsActive;
                employeemodel.DepartmentId = employee.DepartmentId;
                employeemodel.Email = employee.Email;
                
                     
             }

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        //get

        public ActionResult Delete(int id)
        {
            var model = GetEmployee(id);
            return View(model);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id ,  EmployeeModel employee)
        {
            try
            {
                var model = GetEmployee(id);
                if(model != null)
                {
                    _dbContext.Employees.Remove(model);

                    _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
