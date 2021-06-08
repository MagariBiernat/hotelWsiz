using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        [Range(1,1000)]
        public double PricePerNight { get; set; }
    
        [Required]
        [Range(1,3)]
        public int StandardQuality { get; set; }

        [Required]
        public int BedsQuantity { get; set; }

        [Required]
        public bool IsApartament { get; set; }

        
    }

}
