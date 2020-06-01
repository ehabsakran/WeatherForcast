using Microsoft.AspNet.Identity;

namespace WeatherForcast.Application.Models.Auth
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}