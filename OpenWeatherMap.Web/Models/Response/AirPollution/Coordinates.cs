using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
