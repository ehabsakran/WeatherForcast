using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Services.MetaWeather
{
    public partial class MetaWeatherService : IWeatherService
    {
        private HttpClient client;

        public MetaWeatherService()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            client = HttpClientFactory.Create();
            client.BaseAddress = new Uri("https://www.metaweather.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<WeatherItem> GetWeatherItems(string location)
        {
            try
            {
                var whereOnEarthId = GetWhereOnEarthId(location);
                var metaWeatherItem = GetMetaWeatherItem(whereOnEarthId);
                var weatherItems = ConvertMetaWeatherItemsToWeatherItems(metaWeatherItem.ConsolidatedWeather);
                return weatherItems;
            }
            catch
            {
                return new List<WeatherItem>();
            }
            
        }

        public MetaWeatherItem GetMetaWeatherItem(long woeId)
        {
            var response = client.GetAsync($"api/location/{woeId}/").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<MetaWeatherItem>(new[] { new JsonMediaTypeFormatter() }).GetAwaiter().GetResult();
                return result;
            }

            return new MetaWeatherItem();
        }
        public long GetWhereOnEarthId(string location)
        {
            var response = client.GetAsync($"api/location/search/?query={location}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<List<WhereOnEarthLocation>>(new[] { new JsonMediaTypeFormatter() }).GetAwaiter().GetResult();
                return result.FirstOrDefault()?.Woeid ?? 0;
            }
            return 0;
        }

        private IEnumerable<WeatherItem> ConvertMetaWeatherItemsToWeatherItems(IEnumerable<ConsolidatedWeather> items)
        {
            var weatherItems = new List<WeatherItem>();
            foreach (var item in items)
            {
                var weatherItem = new WeatherItem
                {
                    ApplicableDate = item.ApplicableDate.Date,
                    State = item.WeatherStateName,
                    StateAbbreviation = item.WeatherStateAbbr
                };
                weatherItems.Add(weatherItem);
            }

            return weatherItems;
        }
    }


}