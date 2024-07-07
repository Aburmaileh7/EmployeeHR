using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
