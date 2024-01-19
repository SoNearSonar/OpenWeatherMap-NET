using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Precipitation
    {
        [JsonPropertyName("total")]
        public double Total { get; set; }
    }
}
