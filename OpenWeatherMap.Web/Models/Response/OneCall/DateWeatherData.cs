using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    // For getting weather data by a specific date (DateTime)
    public class DateWeatherData
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = default!;

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonPropertyName("data")]
        public List<CurrentForecastData> Current { get; set; } = default!;
    }
}
