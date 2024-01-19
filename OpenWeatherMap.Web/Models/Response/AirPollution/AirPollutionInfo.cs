using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionInfo
    {
        [JsonPropertyName("aqi")]
        public int AirQualityIndex { get; set; } = default!;
    }
}
