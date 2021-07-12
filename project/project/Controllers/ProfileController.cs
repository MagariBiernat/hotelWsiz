using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using project.Data;
using project.Models;
using project.Models.AccountViewModels;

namespace project.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public ProfileController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var allBookings = await _context.Bookings.ToListAsync();

            allBookings = allBookings.FindAll(b => b.CustomerId == user.Id);

            return View(allBookings);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile([Bind("FirstName, LastName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.GetUserAsync(User);
                _user.FirstName = applicationUser.FirstName;
                _user.LastName = applicationUser.LastName;

                var result = await _userManager.UpdateAsync(_user);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Profile edited successfully";
                    return RedirectToAction(nameof(Index));
                }
                AddErrors(result);
            }
            // whopsie
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([Bind("newPassword, newPasswordConfirm")] ChangePasswordViewModel applicationUser)
        {
            if (ModelState.IsValid)
            {
                if(applicationUser.newPassword == applicationUser.newPasswordConfirm)
                {
                    var user = await _userManager.GetUserAsync(User);

                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var result = await _userManager.ResetPasswordAsync(user, token, applicationUser.newPassword);

                    if (result.Succeeded)
                    {
                        TempData["Message"] = "Password has been changed successfully";
                        return RedirectToAction(nameof(Index));
                    }

                    AddErrors(result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Passwords do not match");
                }
            }
            return View();
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
