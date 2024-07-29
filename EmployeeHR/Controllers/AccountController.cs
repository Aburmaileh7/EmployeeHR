using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Controllers
{
    public class AccountController : Controller
    {
       private UserManager<IdentityUser> _userManager;
       private SignInManager<IdentityUser> _signInManager;
       private RoleManager<IdentityRole> _roleManager; 


        public AccountController(UserManager<IdentityUser>userManager,
            SignInManager<IdentityUser>signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager=signInManager;
            _roleManager = roleManager ;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegeisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var respone = await _userManager.CreateAsync(user, model.Password);


                if (respone.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach(var err in respone.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var respone = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (respone.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email or pass");
                return View(model);
            }
            return View(model);
        }
    }
}
