using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EmployeeHR.Controllers
{
    public class EmployeeController : Controller
    {

        public static List<EmployeeModel> employees = new List<EmployeeModel>
        {
            new EmployeeModel{
                Id = 1,
                FirstName="Ali",
                LastName="Rami",
                HiringDate=new DateTime(10,12,2024),
                DOB=new DateTime(10,12,2000),
                Salary=500,
                IsActive=true,
                DepartmentId=1,
                Email="ali@gmail.com"
            } ,
            new EmployeeModel{
                Id = 2,
                FirstName="salem",
                LastName="ahmad",
                HiringDate=new DateTime(20,05,2024),
                DOB=new DateTime(10,10,2002),
                Salary=700,
                IsActive=true,
                DepartmentId=2,
                Email="alikll@gmail.com"
            },
            new EmployeeModel{
                Id = 3,
                FirstName="Amal",
                LastName="Rami",
                HiringDate=new DateTime(09,10,2024),
                DOB=new DateTime(20,10,2000),
                Salary=500,
                IsActive=true,
                DepartmentId=1,
                Email="amal@gmail.com"
            } 
            
        };

        public static List<DepartmentModel> departments = new List<DepartmentModel>
        {
            new DepartmentModel{Id=1,Name="Developer",Abbreviation="Div"},
            new DepartmentModel{Id=1,Name="Finance",Abbreviation="Fin"}
        };

        private EmployeeModel GetEmployee(int id)
        {
            var model = employees.Where(x => x.Id == id).FirstOrDefault();
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
            var EmployeeDepartment = (from emp in employees
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
                                      }).ToList();
            return View(EmployeeDepartment);
        }

        //get Details

        public ActionResult Details(int id)
        {
            var EmployeeDepartmentModel = (from emp in employees
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
                

                employees.Add(employee);

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

            var model = employees.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id, EmployeeModel employee)
        {
            try
            {
                var model = employees.Where(x => x.Id == id).FirstOrDefault();
                if (model != null)
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
