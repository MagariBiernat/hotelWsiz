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
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> Index()
        {
            if(!(await checkIfAdmin()))
            {
                RedirectHome();
            }

            var listAllWorkers = await _context.Users.Where(u => u.isSuperAdmin == false).Where(u => u.isWorker == true).ToListAsync();

            return View(listAllWorkers);
        }

        [HttpGet]
        public async Task<ActionResult> CreateNewAccount()
        {
            if (!(await checkIfAdmin()))
            {
                RedirectHome();
            }
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


        [HttpGet]
        public async Task<IActionResult> DeleteWorker(string id)
        {
            if (!(await checkIfAdmin()))
            {
                RedirectHome();
            }

            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string email)
        {
            var u = await _userManager.FindByIdAsync(id);
            var u2 = await _userManager.FindByEmailAsync(email);

            if (!(await checkIfAdmin()))
            {
                RedirectHome();
            }

            var worker = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(worker);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                TempData["Message"] = "There was a problem while deleting user";
                return RedirectToAction(nameof(Index));
            }

            TempData["Message"] = "Account has been deleted successfully";
            return RedirectToAction(nameof(Index));
            
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
