using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class WindMax
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("direction")]
        public double Direction { get; set; }
    }
}
