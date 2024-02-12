using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Precipitation
    {
        [JsonProperty("total")]
        public double Total { get; set; }
    }
}
