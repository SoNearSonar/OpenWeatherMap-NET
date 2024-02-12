using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class Snow
    {
        [JsonProperty("1h")]
        public double OneHour { get; set; }
    }
}
