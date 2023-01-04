using Microsoft.AspNetCore.Identity;
using PermissionManagement.MVC.Constants;
using NAMIS.Models;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<useraccount> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}