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
    public class MessagesController : Controller
    {
        private ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public MessagesController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);

                var allMessages = await _context.Messages.ToListAsync();

                if (user.isWorker || user.isSuperAdmin)
                {
                    allMessages = allMessages.FindAll(m => m.isToWorker);
                }
                else
                {
                    allMessages = allMessages.FindAll(m => !m.isToWorker);

                }

                return View(allMessages);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AnswerMessage(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.SingleOrDefaultAsync(m => m.Id == id);

            if(message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> NewMessage()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SendMessage([Bind("")] Message message)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
