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

            var room = rooms.SingleOrDefault(item => item.RoomId == id);

            ViewBag.Room = room;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookRoom(int? roomId, Booking booking)
        {
            var hotel = await _context.Rooms.SingleOrDefaultAsync(r => r.RoomId == roomId);

            int hotelId = hotel.HotelId;

            if (roomId == null)
            {
                return RedirectToAction(nameof(HotelIndex), new { id = hotelId });
            }
            
            if (ModelState.IsValid)
            {
                var id = -1;
                DateTime startDate = booking.StartDate;
                DateTime endDate = booking.EndDate;

                if(startDate <= DateTime.Today || startDate > endDate)
                {
                    ViewBag.Status = "Wrong dates";
                    return View(booking);
                }

                var activeBookings = _context.Bookings.Where(booking => booking.IsActive);
                var rooms = _context.Rooms;

                foreach(var room in rooms)
                {
                    var activeBookingsForRoom = activeBookings.Where(booking => booking.RoomId == roomId);
                    if(activeBookingsForRoom.All(b => startDate < b.StartDate &&
                        endDate < b.StartDate || startDate > b.EndDate && endDate > b.EndDate))
                    {
                        id = room.RoomId;
                        break;
                    }
                }

                if(id >= 0)
                {
                    var user = await _userManager.GetUserAsync(User);

                    booking.CustomerId = user.Id;
                    booking.RoomId = id;
                    booking.IsActive = true;
                    _context.Bookings.Add(booking);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Room booked successfully";
                    return RedirectToAction(nameof(HotelIndex), new { id = hotelId });
                }
            }

            var allRooms = await _context.Rooms.ToListAsync();

            var roomToPass = allRooms.SingleOrDefault(item => item.RoomId == roomId);

            ViewBag.Status = "The booking could not be created. There were no available room.";
            ViewBag.Room = roomToPass;
            return View(new { id = hotelId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBooking(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(item => item.Id == id);

            if(booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(item => item.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                TempData["Message"] = "There was a problem while deleting user";
                return RedirectToAction(nameof(Index));
            }

            TempData["Message"] = "Account has been deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
