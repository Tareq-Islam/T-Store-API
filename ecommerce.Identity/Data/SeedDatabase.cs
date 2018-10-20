using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace ecommerce.Identity
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            context.Database.EnsureCreatedAsync();

            if (userManager.Users.Any())
            {
                return;
            }


            if (!userManager.Users.Any(u=>u.Email == "tareqislamidb@gmail.com"))
            {
                ApplicationUser user = new ApplicationUser
                {

                    FirstName = "Tareq",
                    LastName = "Islam",
                    UserName = "tareqislamidb",
                    Email = "tareqislamidb@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                userManager.CreateAsync(user, "@Test123");

                IdentityRole role = new IdentityRole
                {
                    Name = "admin"
                };
                roleManager.CreateAsync(role);

                userManager.AddToRoleAsync(user, "admin");

            }


        }
    }
}
