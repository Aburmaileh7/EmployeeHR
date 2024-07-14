using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EmployeeHR.Controllers
{
    public class EmployeeController : Controller
    {

        public static List<EmployeeModel> Employees = new List<EmployeeModel>
        {
            new EmployeeModel{
                Id = 1,
                FirstName="Ali",
                LastName="Rami",
                HiringDate=new DateTime(2024,09,10),
                DOB=new DateTime(2000,10,08),
                Salary=500,
                IsActive=true,
                DepartmentId=1,
                Email="ali@gmail.com"
            } ,
            new EmployeeModel{
                Id = 2,
                FirstName="salem",
                LastName="ahmad",
                HiringDate=new DateTime(2024,02,13),
                DOB=new DateTime(2002,3,20),
                Salary=700,
                IsActive=true,
                DepartmentId=2,
                Email="alikll@gmail.com"
            },
            new EmployeeModel{
                Id = 3,
                FirstName="Amal",
                LastName="Rami",
                HiringDate=new DateTime(2024,3,22),
                DOB=new DateTime(2000,12,03),
                Salary=500,
                IsActive=true,
                DepartmentId=1,
                Email="amal@gmail.com"
            }

        };

        public static List<DepartmentModel> departments = new List<DepartmentModel>
        {
            new DepartmentModel{Id=1,Name="Developer",Abbreviation="Div"},
            new DepartmentModel{Id=2,Name="Finance",Abbreviation="Fin"}
        };

        //private readonly HRDbContext _dbContext;

        //public EmployeeController(HRDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}

        private EmployeeModel GetEmployee(int id)
        {
            var model = Employees.Where(x => x.Id == id).FirstOrDefault();
            if (model!= null)
            {
                return model;
            }
            else
            {
                return new EmployeeModel();
            }
        }
        public IActionResult Index()
        {
            var EmployeeDepartment = (from emp in Employees
                                      join dep in departments on emp.DepartmentId equals dep.Id
                                      select new EmployeeModel
                                      {
                                          Id = emp.Id,
                                          FirstName = emp.FirstName,
                                          LastName = emp.LastName,
                                          HiringDate = emp.HiringDate,

                                          IsActive = emp.IsActive,

                                          DepartmentId = emp.DepartmentId,
                                          Department = dep

                                      }).ToList();

            //var employees= _dbContext.Employees.Include(x => x.Id)
            //                                     .OrderBy(x => x.FirstName).ToList();

            return View(EmployeeDepartment);
        }

        //get Details

        public ActionResult Details(int id)
        {
            var EmployeeDepartmentModel = (from emp in Employees
                                           join dep in departments on emp.DepartmentId equals dep.Id
                                           select new EmployeeModel
                                           {

                                               Id = emp.Id,
                                               FirstName = emp.FirstName,
                                               LastName = emp.LastName,
                                               HiringDate = emp.HiringDate,
                                               DOB = emp.DOB,
                                               IsActive = emp.IsActive,
                                               Salary = emp.Salary,
                                               Email = emp.Email,
                                               DepartmentId = emp.DepartmentId,
                                               Department = dep
                                           }).FirstOrDefault(x => x.Id == id);
            return View(EmployeeDepartmentModel);
        }


        //get Create 

        public ActionResult Create()
        {
            ViewBag.departmentsList = departments;

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employee)
        {
            try
            {


                Employees.Add(employee);
               // _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        { 
            ViewBag.departmentsList = departments;

            var model = Employees.Where(x => x.Id == id).FirstOrDefault();

            if(model != null)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,EmployeeModel employee)
        {
            try
            {
                var model = Employees.Where(x => x.Id == id).FirstOrDefault();

                if(model != null)
                {
                    model.Id = employee.Id;
                    model.FirstName = employee.FirstName;
                    model.LastName = employee.LastName;
                    model.HiringDate = employee.HiringDate;
                    model.DOB = employee.DOB;
                    model.Salary = employee.Salary;
                    model.IsActive = employee.IsActive;
                    model.DepartmentId = employee.DepartmentId;
                    model.Email = employee.Email;

                  //  _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }

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
        public ActionResult Delete(int id , IFormCollection collection)
        {
            try
            {
                var model = GetEmployee(id);
                if(model != null)
                {
                    Employees.Remove(model);

                    //_dbContext.SaveChanges();
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
