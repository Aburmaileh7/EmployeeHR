﻿using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;


        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

		#region Register

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
                   // UserName=new MailAddress(model.Email).User,
                    UserName = model.UserName,
                    Email = model.Email
                };
                var respone = await _userManager.CreateAsync(user, model.Password);


                if (respone.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in respone.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }

		#endregion

		#region login

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
                var respone = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (respone.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email or pass");
                return View(model);
            }
            return View(model);
        }

		#endregion

		#region logOut
		[HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Manage

     
		[HttpGet]
        public async Task<IActionResult> Manage()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            //var user = await _userManager.FindByNameAsync(currentUser.UserName);
            if (currentUser != null)
            {
                var viewModel = new ManageUserViewModel
                {
                    UserName = currentUser.UserName,
                    PhoneNumder = currentUser.PhoneNumber
                };

                return View(viewModel);
            }

            
            return View("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.PhoneNumber = model.PhoneNumder;
                    await _userManager.UpdateAsync(currentUser);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }
    }

}