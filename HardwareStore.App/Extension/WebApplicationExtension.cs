namespace HardwareStore.App.Extension
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Cart;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static Constants.Constants;

    public static class WebApplicationExtension
    {
        
        public static void ApplyMigrations(this WebApplication app)
        {
            var dbContext = app.Services
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }

        public static void SeedAdmin(this WebApplication app)
        {
            var userManager = app.Services
                .CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = app.Services.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var cartService = app.Services.CreateScope().ServiceProvider.GetRequiredService<ICartService>();
            var dbContext = app.Services
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var config = app.Services.GetRequiredService<IConfiguration>();

            var userEmail = config.GetValue<string>("AdminUser_Email");
            var userPassword = config.GetValue<string>("AdminUser_Password");
            var adminUser = new ApplicationUser
            {
                UserName = userEmail,
                Email = userEmail,
                EmailConfirmed = true
            };
            var userExsist = userManager.Users.FirstOrDefault(x => x.Email == adminUser.Email);
            if (userExsist == null)
            {
                userManager.CreateAsync(adminUser, userPassword).GetAwaiter().GetResult();
                var roleExsist = roleManager.Roles.FirstOrDefault(x => x.Name == Roles.Admin);
                if (roleExsist == null)
                {
                    roleManager.CreateAsync(new IdentityRole
                    {
                        Name = Roles.Admin,
                    });
                }

                userManager.AddToRoleAsync(adminUser, Roles.Admin).GetAwaiter().GetResult();
                var cart = new Cart
                {
                    
                    ApplicationUserId = adminUser.Id,
                };
                dbContext.Carts.Add(cart);               
                dbContext.SaveChanges();

            }

        }
    }
}
