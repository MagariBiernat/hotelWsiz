using System;
using System.Collections.Generic;
using System.Linq;
using project.Models;

namespace project.Data
{
    public static class DbInitialize
    {
        public static void Initialize(ApplicationDbContext context)
        {

            if (!context.Hotels.Any())
            {

                List<Room> rooms = new List<Room>
                {
                    new Room { RoomNumber=1, PricePerNight=200, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=2, PricePerNight=250, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=3, PricePerNight=200, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=4, PricePerNight=300, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=5, PricePerNight=250, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=6, PricePerNight=200, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=7, PricePerNight=250, StandardQuality=2, BedsQuantity=2},
                    new Room { RoomNumber=8, PricePerNight=400, StandardQuality=3, BedsQuantity=4},
                    new Room { RoomNumber=9, PricePerNight=400, StandardQuality=3, BedsQuantity=4},
                    new Room { RoomNumber=10, PricePerNight=500, StandardQuality=3, BedsQuantity=4},
                };

                List<Hotel> hotels = new List<Hotel>
                {
                    new Hotel { Name = "Hotel Grand", City="Warsaw", Country="Poland", Stars=4, AllRooms=rooms},
                    new Hotel { Name = "Hotel Superb", City="Warsaw", Country="Poland", Stars=4, AllRooms=rooms},
                    new Hotel { Name = "Hotel Tajwand", City="Krakow", Country="Poland", Stars=5, AllRooms=rooms},
                };

                context.Hotels.AddRange(hotels);
                context.SaveChanges();
            }
        }
    }
}
