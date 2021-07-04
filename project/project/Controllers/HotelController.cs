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
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public HotelController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // all hotels main page
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hotels.ToListAsync());
        }


        //get that one hotel
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> HotelIndex(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .SingleOrDefaultAsync(item => item.Id == id);

            if(hotel == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms.ToListAsync();
            ViewBag.Rooms = rooms.FindAll(item => item.HotelId == id);
           
            return View(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> BookRoom(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms.ToListAsync();

            rooms = rooms.FindAll(r => r.HotelId == id);

            ViewData["RoomId"] = new SelectList(rooms, "RoomId", "RoomId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookRoom(Booking booking)
        {
            return View();
        }
    }
}
