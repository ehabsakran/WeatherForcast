using Newtonsoft.Json;

namespace WeatherForecast.Application.Services.MetaWeather
{
    public partial class MetaWeatherService
    {
        private class WhereOnEarthLocation
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("location_type")]
            public string LocationType { get; set; }

            [JsonProperty("woeid")]
            public long Woeid { get; set; }

            [JsonProperty("latt_long")]
            public string LattLong { get; set; }
        }
    }


}