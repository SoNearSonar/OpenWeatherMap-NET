using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Wind
    {
        [JsonPropertyName("max")]
        public WindMax Max { get; set; } = default!;
    }
}
