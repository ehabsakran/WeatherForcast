using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast;
using WeatherForecast.Application.Models;
using WeatherForecast.Controllers;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ModelForBelfast_GivenBelfastAsLocation()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            PartialViewResult result = controller.LoadWeather("belfast") as PartialViewResult;
            WeatherForecastViewModel model = result.Model as WeatherForecastViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual("Belfast", model.Location);
        }
    }
}
