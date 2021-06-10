using Microsoft.AspNetCore.Identity;

namespace project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public bool isWorker { get; set; }
    }
}
