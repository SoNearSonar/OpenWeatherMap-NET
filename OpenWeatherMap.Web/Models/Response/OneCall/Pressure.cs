using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Pressure
    {
        [JsonPropertyName("afternoon")]
        public double Afternoon { get; set; }
    }
}
