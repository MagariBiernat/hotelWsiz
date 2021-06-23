using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using project.Models;
using project.Models.AccountViewModels;
using project.Data;

namespace project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public AdminController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewAccount([Bind()]RegisterWorkerViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, isWorker = true };
                var defaultPassword = "Password123$";
                var result = await _userManager.CreateAsync(user, defaultPassword);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Account has been created successfully";
                    return RedirectToAction(nameof(Index));
                }
                AddErrors(result);
            }

            //Whopsiee
            return View(model);
        }

        private async Task<bool> checkIfAdmin()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user.isSuperAdmin)
                {
                    return true;
                }
            }
            return false;
        }

        private IActionResult RedirectHome()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
