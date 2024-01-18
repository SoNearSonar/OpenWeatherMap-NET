using OpenWeatherMap.Web.Models;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web
{
    public class WeatherData
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; } = default!;

        [JsonPropertyName("lon")]
        public double Longitude { get; set; } = default!;

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = default!;

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; } = default!;

        [JsonPropertyName("current")]
        public CurrentForecastData Current { get; set; } = default!;

        [JsonPropertyName("minutely")]
        public List<MinutelyForecastData> Minutely { get; set; } = default!;

        [JsonPropertyName("hourly")]
        public List<HourlyForecastData> Hourly { get; set; } = default!;

        [JsonPropertyName("daily")]
        public List<DailyForecastData> Daily { get; set; } = default!;
    }
}
