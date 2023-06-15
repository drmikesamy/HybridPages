using HybridPages.Server.Enums;
using HybridPages.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace HybridPages.Server.Data
{
    public class ApplicationDbInitialiser
    {
        public static void SeedRolesAndUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in Enum.GetNames(typeof(RoleEnum)))
            {
                if (roleManager.FindByNameAsync(roleName).Result == null)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper(),
                    };
                    roleManager.CreateAsync(role).Wait();
                }
            }
            if (userManager.FindByEmailAsync("test@test.test").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "test",
                    Email = "test@test.test"
                };

                IdentityResult result = userManager.CreateAsync(user, "12345*Abcde").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
