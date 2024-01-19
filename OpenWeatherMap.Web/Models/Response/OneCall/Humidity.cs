using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Humidity
    {
        [JsonPropertyName("afternoon")]
        public double Afternoon { get; set; }
    }
}
