using Microsoft.AspNet.Identity;

namespace WeatherForecast.Application.Models.Auth
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}