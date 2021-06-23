using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class SeedUsers
    {
        private ApplicationDbContext _context;

        public SeedUsers(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedDataAdmin()
        {
            var admin = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Admin",
                isSuperAdmin = true,
                isWorker = true,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if(!_context.Users.Any( u => u.UserName == admin.UserName))
            {
                var hashedPassword = new PasswordHasher<ApplicationUser>();
                admin.PasswordHash = hashedPassword.HashPassword(admin, "Password123");

                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(admin);
                await userStore.AddToRoleAsync(admin, "admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}
