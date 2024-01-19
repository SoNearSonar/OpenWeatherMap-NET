using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class DailyTemperature
    {
        [JsonPropertyName("min")]
        public double Min { get; set; }

        [JsonPropertyName("max")]
        public double Max { get; set; }

        [JsonPropertyName("afternoon")]
        public double Afternoon { get; set; }

        [JsonPropertyName("night")]
        public double Night { get; set; }

        [JsonPropertyName("evening")]
        public double Eve { get; set; }

        [JsonPropertyName("morning")]
        public double Morning { get; set; }
    }
}
