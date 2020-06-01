using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Application.Services;
using WeatherForecast.Application.Services.MetaWeather;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = GetWeatherData("belfast");
            return View(model);
        }

        public ActionResult LoadWeather(string location)
        {
            var model = GetWeatherData(location);
            return PartialView("_WeatherData", model);
        }

        private WeatherForecastViewModel GetWeatherData(string location)
        {
            IWeatherService service = new MetaWeatherService();

            var weatherItems = service.GetWeatherItems(location);
            var top5Items = weatherItems.Count() > 4 ? weatherItems.Take(5) : weatherItems;

            WeatherForecastViewModel model = new WeatherForecastViewModel
            {
                WeatherItems = top5Items,
                Location = location
            };

            return model;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}