using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class CloudCover
    {
        [JsonPropertyName("afternoon")]
        public double Afternoon { get; set; }
    }
}
