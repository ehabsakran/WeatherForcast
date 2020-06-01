using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WeatherForecast.Application.Services.MetaWeather;

namespace WeatherForecast.Tests.Services
{
    [TestClass]
    public class MetaWeatherServiceTest
    {
        [TestMethod]
        public void GetWhereOnEarthId_GivenBelfastAsLocation()
        {
            string location = "belfast";
            MetaWeatherService service = new MetaWeatherService();

            var woeId = service.GetWhereOnEarthId(location);

            Assert.AreEqual(44544, woeId);
        }

        [TestMethod]
        public void GetMetaWeatherItems_GivenBelfastAsWhereOnEarthId()
        {
            long belfastWoeId = 44544;
            MetaWeatherService service = new MetaWeatherService();

            var weatherItems = service.GetMetaWeatherItem(belfastWoeId);

            Assert.AreEqual(44544, weatherItems.WhereOnEarthId);
        }

        [TestMethod]
        public void GetWeatherItems_GivenBelfastAsLocation()
        {
            string location = "belfast";
            MetaWeatherService service = new MetaWeatherService();

            var weatherItems = service.GetWeatherItems(location);

            Assert.AreEqual(6, weatherItems.Count());
        }
    }
}
