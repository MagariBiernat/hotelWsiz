using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.AccountViewModels
{
    public class RegisterWorkerViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

    }
}
