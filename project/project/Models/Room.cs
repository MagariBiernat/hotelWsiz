using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [Range(1,1000)]
        public double PricePerNight { get; set; }
    
        [Required]
        [Range(1,3)]
        public int StandardQuality { get; set; }

        [Required]
        public int BedsQuantity { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        public string urlToImage { get; set; }
    }

}
