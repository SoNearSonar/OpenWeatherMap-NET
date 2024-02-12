using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
