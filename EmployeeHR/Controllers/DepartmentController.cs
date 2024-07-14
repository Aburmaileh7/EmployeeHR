using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {

        private DepartmentModel GetDepartment(int id)
        {
            var model = departments.Where(x => x.Id == id).FirstOrDefault();
            if (model!=null)
            {
                return model;
            }
            else
            {
                return new DepartmentModel();
            }
        }

        public static List<DepartmentModel> departments = new List<DepartmentModel>
        {
             new DepartmentModel{Id=1,Name="Developer",Abbreviation="Div"},
            new DepartmentModel{Id=2,Name="Finance",Abbreviation="Fin"}
        };


        //private readonly HRDbContext _dbcontext;
        //public DepartmentController(HRDbContext dbcontext)
        //{
        //    this._dbcontext = dbcontext;
        //}
        public IActionResult Index()
        {
            return View(departments);
        }


        public ActionResult Edit(int id)
        {
            var model = departments.FirstOrDefault (x => x.Id == id);
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

            try
            {
                var model = departments.Where(x => x.Id ==id).FirstOrDefault();

                if (model != null)
                {
                    model.Id = department.Id;
                    model.Name = department.Name;
                    model.Abbreviation = department.Abbreviation;



                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(DepartmentModel department)
        {
            try
            {
                var departments = new List<DepartmentModel>();
                departments.Add(department);
                //_dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            var model = GetDepartment(id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentModel department)
        {
            try
            {
                var model = GetDepartment(id);
                if (model != null)
                {
                    departments.Remove(model);
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
           
          
        }


        public ActionResult Details(int id)
        {
     
            return View(departments);
        }



    }
   
    }

