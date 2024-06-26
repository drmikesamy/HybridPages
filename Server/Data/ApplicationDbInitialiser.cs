﻿using HybridPages.Server.Enums;
using HybridPages.Server.Models;
using HybridPages.Shared.Models.Forms.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HybridPages.Server.Data
{
    public class ApplicationDbInitialiser
    {
        public static void SeedRolesAndUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
			foreach (var roleName in Enum.GetNames<RoleEnum>())
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
                    UserName = "test@test.test",
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
