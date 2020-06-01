using Newtonsoft.Json;

namespace WeatherForecast.Application.Services.MetaWeather
{
    public partial class MetaWeatherService
    {
        public class MetaWeatherItem
        {
            [JsonProperty("consolidated_weather")]
            public ConsolidatedWeather[] ConsolidatedWeather { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("location_type")]
            public string LocationType { get; set; }

            [JsonProperty("woeid")]
            public long WhereOnEarthId { get; set; }
        }
    }


}