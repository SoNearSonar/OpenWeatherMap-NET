using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Snow
    {
        [JsonPropertyName("1h")]
        public double OneHour { get; set; }
    }
}
