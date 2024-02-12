using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Humidity
    {
        [JsonProperty("afternoon")]
        public double Afternoon { get; set; }
    }
}
