using System;
using System.Threading.Tasks;
using coreTest11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace coreTest11.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // creating a super user who could maintain the web app
            var poweruser = new Users
            {
                //UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                //Email = Configuration.GetSection("AppSettings")["UserEmail"]
                UserName = "super@gmail.com",
                Email = "super@gmail.com"
            };
//            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            string userPassword = "A1234567!a";
//            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
            var user = await UserManager.FindByEmailAsync("super@gmail.com");
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
