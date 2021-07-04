using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using project.Data;
using Microsoft.EntityFrameworkCore;

namespace project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    var user = await _userManager.GetUserAsync(User);
            //    ViewData["FullName"] = user.getFullName();
            //};
            return View(await _context.Hotels.ToListAsync());
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

    }
}
