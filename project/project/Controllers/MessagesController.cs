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

                allMessages = allMessages.FindAll(m => !m.isAnswered);

                return View(allMessages);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AllMessages()
        {
            var user = await _userManager.GetUserAsync(User);

            var allMessages = await _context.Messages.ToListAsync();

            allMessages = allMessages.FindAll(m => m.ToEmail == user.Email);

            return View(allMessages);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnswerMessage(Message message)
        { 
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                Message newMessage = new Message
                {
                    DateTime = DateTime.Now,
                    FromEmail = user.Email,
                    isToWorker = !user.isWorker,
                    isAnswer = true,
                    isAnswerTo = message.Id,
                    MessageContent = message.MessageContent,
                    ToEmail = message.FromEmail,
                    isAnswered = true
                };

                await _context.Messages.AddAsync(newMessage);

                var result = await _context.SaveChangesAsync();

                if(result > 0)
                {
                    var msg = await _context.Messages.SingleOrDefaultAsync(m => m.Id == message.Id);

                    msg.isAnswered = true;

                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Message sent successfully";
                }
                else
                {
                    TempData["Message"] = "There was a problem answering";
                }
                return RedirectToAction(nameof(Index));

            }

            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewMessage([Bind("MessageContent")] Message message)
        {
            var user = await _userManager.GetUserAsync(User);

            message.DateTime = DateTime.Now;
            message.FromEmail = user.Email;
            message.isAnswer = false;
            message.isToWorker = false;
            message.ToEmail = "";
            message.isAnswered = false;

            if (ModelState.IsValid)
            {
                if(user.isWorker)
                {
                    var allUsers = await _context.Users.ToListAsync();

                    allUsers = allUsers.FindAll(u => !u.isWorker && !u.isSuperAdmin);

                    allUsers.ForEach(async (item) =>
                    {
                       var newMessage = message;
                       message.ToEmail = item.Email;
                       await _context.Messages.AddAsync(newMessage);
                    });
                }
                else
                {
                    message.isToWorker = true;
                    await _context.Messages.AddAsync(message);
                }

                var result = await _context.SaveChangesAsync();
                if(result > 0)
                {
                    TempData["Message"] = "Message sent successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    return View(message);
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
