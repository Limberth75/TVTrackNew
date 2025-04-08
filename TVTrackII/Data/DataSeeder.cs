using Microsoft.AspNetCore.Identity;
using TVTrackII.Models;

namespace TVTrackII.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Roles
            var roles = new[] { "Administrador", "Usuario" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Usuario administrador
            var adminEmail = "admin@tvtrack.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    NombreCompleto = "Administrador",
                    Rol = "Administrador",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Password123!");
                await userManager.AddToRoleAsync(admin, "Administrador");
            }

            // Usuario común
            var userEmail = "usuario@tvtrack.com";
            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    NombreCompleto = "Usuario Regular",
                    Rol = "Usuario",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Password123!");
                await userManager.AddToRoleAsync(user, "Usuario");
            }
        }
    }
}
