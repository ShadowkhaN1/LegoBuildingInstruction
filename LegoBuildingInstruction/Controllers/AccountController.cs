using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<LegoUser> _signInManager;
        private readonly UserManager<LegoUser> _userManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<LegoUser> signInManager, UserManager<LegoUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {


                var result = await _signInManager.PasswordSignInAsync(model.Email,
                  model.Password,
                  model.RememberMe,
                  false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }


                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }



            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {


            if (ModelState.IsValid)
            {
                var user = new LegoUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    if (!error.Description.Contains("Username"))
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }
    }
}
