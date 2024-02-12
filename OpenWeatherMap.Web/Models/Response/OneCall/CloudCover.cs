using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class CloudCover
    {
        [JsonProperty("afternoon")]
        public double Afternoon { get; set; }
    }
}
