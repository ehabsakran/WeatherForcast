using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Services
{
    interface IWeatherService
    {
        IEnumerable<WeatherItem> GetWeatherItems(string location);
    }
}
