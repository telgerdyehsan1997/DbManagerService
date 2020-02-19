using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class SystemIdentityContextSeed
    {
        public static async Task SeedAsync(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.Administrators));
            }

            if (userManager.Users.Any())
            {

                var defaultUser = new SystemUser { UserName = "ehsanTLD", Email = "ehsantelgerdyaa1@.com" };
                await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

                string adminUserName = "ehsantelgerdybb1@gmail.com";
                var adminUser = new SystemUser { UserName = adminUserName, Email = adminUserName };
                await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
                adminUser = await userManager.FindByNameAsync(adminUserName);
                await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.Administrators);

            }


        }
    }
}
