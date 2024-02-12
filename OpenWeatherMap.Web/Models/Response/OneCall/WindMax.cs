using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class WindMax
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("direction")]
        public double Direction { get; set; }
    }
}
