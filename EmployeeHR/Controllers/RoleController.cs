using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel role)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",await _roleManager.Roles.ToListAsync());
            }

            var isRoleExists = await _roleManager.RoleExistsAsync(role.Name);
            
            if (isRoleExists)
            {
                ModelState.AddModelError("Name", "Role is Exist");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }

            await _roleManager.CreateAsync(new IdentityRole { Name = role.Name.Trim() });
            return RedirectToAction(nameof(Index));
        }

        
    }
}
