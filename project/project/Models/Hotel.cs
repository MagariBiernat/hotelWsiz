using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Range(1,5)]
        public int Stars { get; set; }

        public List<Room> AllRooms { get; set; }

    }
}
