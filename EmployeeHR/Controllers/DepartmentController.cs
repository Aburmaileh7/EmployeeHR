using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {

        //database/////////////////////
        private readonly HRDBContext _dbcontext;
        public DepartmentController(HRDBContext dbcontext)
        {
            this._dbcontext= dbcontext;
        }



        // GET: DepartmentController
        public ActionResult Index()
        {
            var departmentList = _dbcontext.Departments.ToList();
            return View(departmentList);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]

        public ActionResult Create(DepartmentModel department)
        {
          if(department != null)
            {
                _dbcontext.Departments.Add(department);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
          return View();
        }



        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            if(model != null)
            {
                return View("Create", model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
   
        public ActionResult Edit(int id, DepartmentModel department)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Name = department.Name;
                model.Abbreviation = department.Abbreviation;
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", department);
        }



        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentModel department)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                _dbcontext.Departments.Remove(model);
                _dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var model = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }



    }
}
