using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public bool isWorker { get; set; }
        public bool isSuperAdmin { get; set; }


        public string getFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        //public string newPassword { get; set; }
        //public string newPasswordConfirm { get; set; }

        //public override
    }
}
