using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class WeatherFeelsLike : IDetailedItem
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }

        [JsonPropertyName("night")]
        public double Night { get; set; }

        [JsonPropertyName("eve")]
        public double Eve { get; set; }

        [JsonPropertyName("morn")]
        public double Morning { get; set; }
    }
}
