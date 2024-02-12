using Newtonsoft.Json;
using OpenWeatherMap.Web.Models;
using System.Collections.Generic;

namespace OpenWeatherMap.Web
{
    public class WeatherData
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonProperty("current")]
        public CurrentForecastData Current { get; set; }

        [JsonProperty("minutely")]
        public List<MinutelyForecastData> Minutely { get; set; }

        [JsonProperty("hourly")]
        public List<HourlyForecastData> Hourly { get; set; }

        [JsonProperty("daily")]
        public List<DailyForecastData> Daily { get; set; }
        
        [JsonProperty("alerts")]
        public List<Alert> Alerts { get; set; }
    }
}
