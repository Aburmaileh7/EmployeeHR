using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly HRDbContext _dbcontext;
        public DepartmentController(HRDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View(_dbcontext.Departments);
        }


        public ActionResult Edit(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault
                (x => x.Id == id);

            return View("Create", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentModel department)
        {

            try
            {
                var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);

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

            _dbcontext.Departments.Add(department);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));

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
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Details(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }



    }
   
    }

