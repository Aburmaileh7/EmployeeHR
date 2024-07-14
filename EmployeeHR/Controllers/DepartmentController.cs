using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly HRDbContext _dbcontext;
        public DepartmentController(HRDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

     

        //public static List<DepartmentModel> departments = new List<DepartmentModel>
        //{
        //     new DepartmentModel{Id=1,Name="Developer",Abbreviation="Div"},
        //    new DepartmentModel{Id=2,Name="Finance",Abbreviation="Fin"}
        //};


     
        public IActionResult Index()
        {
            var departmentList = _dbcontext.Departments.ToList();
            return View(departmentList);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(DepartmentModel department)
        {
           if(department!= null)
            {
                _dbcontext.Departments.Add(department);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
              
                return View();
        }


        public ActionResult Edit(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault (x => x.Id == id);
            if(model!= null)
            {
                return View("Create", model);
            }

            return RedirectToAction(nameof(Index));
            

        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentModel department)
        {

           
                var model = _dbcontext.Departments.Where(x => x.Id ==id).FirstOrDefault();
                if (model != null)
                {
                    model.Name = department.Name;
                    model.Abbreviation = department.Abbreviation;
                    _dbcontext.SaveChanges();

                     return RedirectToAction(nameof(Index));
                }
               
            
                return View("Create", department);
            
        }


        public ActionResult Delete(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentModel department)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                _dbcontext.Departments.Remove(model);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
        


        public ActionResult Details(int id)
        {
     
            return View(_dbcontext.Departments);
        }



    }
   
    }

