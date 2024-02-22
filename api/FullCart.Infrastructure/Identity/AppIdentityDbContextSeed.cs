using FullCart.Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;

namespace FullCart.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any()){
                var user = new AppUser
                {
                    DisplayName = "Faris",
                    Email = "faris@test.com",
                    UserName = "faris@test.com",
                    Address = new Address
                    {
                        FirstName = "Mohideen Ibrahim",
                        LastName = "Faris",
                        Street = "78, North Street",
                        City = "Chennai",
                        State = "TamilNadu",
                        ZipCode = "600001"
                    }
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}