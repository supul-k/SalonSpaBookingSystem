using Microsoft.AspNetCore.Identity;

namespace SalonSpaBookingSystem.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("SalonOwner"))
            {
                await roleManager.CreateAsync(new IdentityRole("SalonOwner"));
            }
            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }
    }
}
