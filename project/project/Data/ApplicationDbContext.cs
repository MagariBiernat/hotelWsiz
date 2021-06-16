using System;
using System.Collections.Generic;
using System.Text;
using project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
            base.OnModelCreating(modelBuilder);

            

            

            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel { Id = 1, Name = "Hotel Grand", City = "Warsaw", Country = "Poland", Stars = 4},
                    new Hotel { Id = 2, Name = "Hotel Superb", City = "Warsaw", Country = "Poland", Stars = 4  },
                    new Hotel { Id = 3, Name = "Hotel Tajwand", City = "Krakow", Country = "Poland", Stars = 5 }
                );


            modelBuilder.Entity<Room>().HasData(
                    new Room { RoomNumber = 1, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 2, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 3, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 4, HotelId = 1, PricePerNight = 300, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 5, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 6, HotelId = 1, PricePerNight = 200, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 7, HotelId = 1, PricePerNight = 250, StandardQuality = 2, BedsQuantity = 2, IsApartament = false },
                    new Room { RoomNumber = 8, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomNumber = 9, HotelId = 1, PricePerNight = 400, StandardQuality = 3, BedsQuantity = 4, IsApartament = true },
                    new Room { RoomNumber = 10, HotelId = 1, PricePerNight = 500, StandardQuality = 3, BedsQuantity = 5, IsApartament = true }
                );
        }

        




    }
}
