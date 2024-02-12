using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionInfo
    {
        [JsonProperty("aqi")]
        public int AirQualityIndex { get; set; }
    }
}
