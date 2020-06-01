using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;
using WeatherForecast.Application.Helpers;
using WeatherForecast.Application.Models;

namespace WeatherForecast.ViewModels
{
    public class WeatherForecastViewModel
    {
        private string location = string.Empty;
        public IEnumerable<WeatherItem> WeatherItems { get; set; }
        public string Location { get { return location.ToTitleCase(); } set { location = value; } }
    }
}