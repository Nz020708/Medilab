using Medilab.ViewModels;
using Medilab.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medilab.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager { get;  }

        private SignInManager<IdentityUser> _signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "AdminPanel" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ViewModels.Account.CreateVM model)
        {
      
            if (ModelState.IsValid)
            {
                var admin = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(admin, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(admin, isPersistent: false);
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "AdminPanel" });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
        
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM admin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(admin.Email, admin.Password, admin.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Blog",new { area="AdminPanel"});
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(admin);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
