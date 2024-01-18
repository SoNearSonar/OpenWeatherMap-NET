using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class MinutelyForecastData : IGeneralForecastData
    {
        [JsonPropertyName("dt")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
    }
}
