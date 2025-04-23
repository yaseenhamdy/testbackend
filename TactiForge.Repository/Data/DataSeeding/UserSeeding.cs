using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TactiForge.Core.Identity;

namespace TactiForge.Repository.Data.DataSeeding
{
    public static class UserSeeding
    {
        public async static Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (!await _userManager.Users.AnyAsync())
            {
                var user = new AppUser()
                {
                    Email = "ahmedadmin@gmail.com",
                    DisplayName = "Ansary",
                    UserName = "AhmedElAnsary",
                    PhoneNumber = "01022079103",
                };

                await _userManager.CreateAsync(user, "Admin@123");
            }
        }
    }
}




