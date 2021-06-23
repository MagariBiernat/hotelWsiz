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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().Property(f => f.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel { Id = 1, Name = "Hotel Grand", City = "Warsaw", Country = "Poland", Stars = 4},
                    new Hotel { Id = 2, Name = "Hotel Superb", City = "Warsaw", Country = "Poland", Stars = 4  },
                    new Hotel { Id = 3, Name = "Hotel Tajwand", City = "Krakow", Country = "Poland", Stars = 5 }
                );

            

            modelBuilder.Entity<Room>().HasData(
                    new Room { Id=1, RoomNumber = 1, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 2, RoomNumber = 2, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 3, RoomNumber = 3, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 4, RoomNumber = 4, HotelId = 1, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 5, RoomNumber = 5, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 6, RoomNumber = 6, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 7, RoomNumber = 7, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 8, RoomNumber = 8, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 9, RoomNumber = 9, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 10, RoomNumber = 10, HotelId = 1, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true },
                    new Room { Id = 11, RoomNumber = 1, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 12, RoomNumber = 2, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 13, RoomNumber = 3, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 14, RoomNumber = 4, HotelId = 2, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 15, RoomNumber = 5, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 16, RoomNumber = 6, HotelId = 2, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 17, RoomNumber = 7, HotelId = 2, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 18, RoomNumber = 8, HotelId = 2, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 19, RoomNumber = 9, HotelId = 2, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 20, RoomNumber = 10, HotelId = 2, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true },
                    new Room { Id = 21, RoomNumber = 1, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 22, RoomNumber = 2, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 23, RoomNumber = 3, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 24, RoomNumber = 4, HotelId = 3, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 25, RoomNumber = 5, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 26, RoomNumber = 6, HotelId = 3, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 27, RoomNumber = 7, HotelId = 3, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { Id = 28, RoomNumber = 8, HotelId = 3, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 29, RoomNumber = 9, HotelId = 3, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { Id = 30, RoomNumber = 10, HotelId = 3, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
