using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeatherMap.Web.Models
{
    // For getting weather data by a specific date (DateTime)
    public class DateWeatherData
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonProperty("data")]
        public List<CurrentForecastData> Current { get; set; }
    }
}
