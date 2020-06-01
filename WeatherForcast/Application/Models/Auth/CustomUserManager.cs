using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Models.Auth
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager()
            : base(new CustomUserSore<ApplicationUser>())
        {

        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            var taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                if (userName == "username" && password == "password")
                {
                    return new ApplicationUser { Id = "NeedsAnId", UserName = "Username" };
                }
                return null;
            });

            return taskInvoke;
        }
    }
}