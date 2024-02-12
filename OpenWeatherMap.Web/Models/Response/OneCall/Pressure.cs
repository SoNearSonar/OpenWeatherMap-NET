using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Pressure
    {
        [JsonProperty("afternoon")]
        public double Afternoon { get; set; }
    }
}
