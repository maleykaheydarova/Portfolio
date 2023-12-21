using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;
namespace Portfolio.Classes
{
    public static class SeedData
    {
        public static void GenerateFirstUser(UserManager<User> userManager)
        {
            var user = new User
            {
                UserName = "Admin",
                Email = ""
            };
            userManager.CreateAsync(user, "1234");
        } 
    }
}
