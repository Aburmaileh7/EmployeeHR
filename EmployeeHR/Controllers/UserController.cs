using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController( UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public  async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Email=x.Email,
                Roles=_userManager.GetRolesAsync(x).Result
            }).ToListAsync();
            return View(users);
        }

       
        public async Task<IActionResult> Manage(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    RoleName = x.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, x.Name).Result
                }).ToList()
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Manage(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            var rolesToRemove = await _userManager.GetRolesAsync(user);

            var resoonse = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            if (resoonse.Succeeded)
            {
                var rolesToAdd = model.Roles.Where(x => x.IsSelected).Select(x => x.RoleName).ToList();
                var res = await _userManager.AddToRolesAsync(user, rolesToAdd);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

