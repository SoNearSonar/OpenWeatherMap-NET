using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double OneHour { get; set; }
    }
}
