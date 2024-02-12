using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Wind
    {
        [JsonProperty("max")]
        public WindMax Max { get; set; }
    }
}
