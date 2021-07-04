using System;
using System.Collections.Generic;
using System.Text;
using project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().Property(f => f.RoomId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Booking>().Property(f => f.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel { Id = 1, Name = "Hotel Grand", City = "Warsaw", Country = "Poland", Stars = 4, urlToImage = "https://u.profitroom.pl/2017.hotelsopot.eu/thumb/1920x1080/uploads/HS_foto.jpg" },
                    new Hotel { Id = 2, Name = "Hotel Superb", City = "Warsaw", Country = "Poland", Stars = 4, urlToImage = "https://www.promenadahotel.pl/htm/a/foto/glowna/Promenada-18x.jpg" },
                    new Hotel { Id = 3, Name = "Hotel Tajwand", City = "Krakow", Country = "Poland", Stars = 5, urlToImage = "https://u.profitroom.pl/2018.windsorhotel.pl/thumb/1200x630/uploads/HotelWindsorwJachrance_HR_257.jpg" },
                    new Hotel { Id = 4, Name = "Hotel Shine", City = "Athnes", Country = "Greece", Stars = 5, urlToImage = "https://r.cdn.redgalaxy.com/http/o2/TUI/hotels/AYT53013/S20/14283763.jpg" }
                );

            

            modelBuilder.Entity<Room>().HasData(
                    new Room { RoomId=1, RoomNumber = 1, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 2, RoomNumber = 2, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 3, RoomNumber = 3, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 4, RoomNumber = 4, HotelId = 1, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 5, RoomNumber = 5, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 6, RoomNumber = 6, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 7, RoomNumber = 7, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 8, RoomNumber = 8, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 9, RoomNumber = 9, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 10, RoomNumber = 10, HotelId = 1, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true },
                    new Room { RoomId = 11, RoomNumber = 1, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 12, RoomNumber = 2, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 13, RoomNumber = 3, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 14, RoomNumber = 4, HotelId = 2, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 15, RoomNumber = 5, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 16, RoomNumber = 6, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 17, RoomNumber = 7, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 18, RoomNumber = 8, HotelId = 2, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 19, RoomNumber = 9, HotelId = 2, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 20, RoomNumber = 10, HotelId = 2, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true },
                    new Room { RoomId = 21, RoomNumber = 1, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 22, RoomNumber = 2, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 23, RoomNumber = 3, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 24, RoomNumber = 4, HotelId = 3, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 25, RoomNumber = 5, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 26, RoomNumber = 6, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 27, RoomNumber = 7, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 28, RoomNumber = 8, HotelId = 3, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 29, RoomNumber = 9, HotelId = 3, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 30, RoomNumber = 10, HotelId = 3, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true },
                    new Room { RoomId = 31, RoomNumber = 1, HotelId = 4, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 32, RoomNumber = 2, HotelId = 4, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 33, RoomNumber = 3, HotelId = 4, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 34, RoomNumber = 4, HotelId = 4, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomId = 35, RoomNumber = 5, HotelId = 4, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomId = 36, RoomNumber = 6, HotelId = 4, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
