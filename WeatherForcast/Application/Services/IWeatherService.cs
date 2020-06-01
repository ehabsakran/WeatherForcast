using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForcast.Application.Models;

namespace WeatherForcast.Application.Services
{
    interface IWeatherService
    {
        IEnumerable<WeatherItem> GetWeatherItems(string location);
    }
}
