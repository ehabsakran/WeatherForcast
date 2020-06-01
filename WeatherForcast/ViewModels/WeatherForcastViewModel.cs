using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;
using WeatherForcast.Application.Helpers;
using WeatherForcast.Application.Models;

namespace WeatherForcast.ViewModels
{
    public class WeatherForcastViewModel
    {
        private string location = string.Empty;
        public IEnumerable<WeatherItem> WeatherItems { get; set; }
        public string Location { get { return location.ToTitleCase(); } set { location = value; } }
    }
}