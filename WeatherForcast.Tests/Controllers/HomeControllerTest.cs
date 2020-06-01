using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForcast;
using WeatherForcast.Application.Models;
using WeatherForcast.Controllers;
using WeatherForcast.ViewModels;

namespace WeatherForcast.Tests.Controllers
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
            WeatherForcastViewModel model = result.Model as WeatherForcastViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual("Belfast", model.Location);
        }
    }
}
