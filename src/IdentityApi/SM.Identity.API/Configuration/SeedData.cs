using Microsoft.AspNetCore.Identity;
using SM.Identity.API.Data;
using System.Threading.Tasks;

namespace SM.Identity.API.Configuration
{
    public static class SeedData
    {
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (!await roleManager.RoleExistsAsync("ChannelAdmin"))
            {
                await roleManager.CreateAsync(new IdentityRole("ChannelAdmin"));
            }

            // Seed users
            var user = new IdentityUser
            {
                UserName = "user@example.com",
                Email = "user@example.com"
            };
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "Password123!");
                await userManager.AddToRoleAsync(user, "User");
            }

            var admin = new IdentityUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com"
            };
            if (await userManager.FindByEmailAsync(admin.Email) == null)
            {
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "ChannelAdmin");
            }
        }
    }
}
