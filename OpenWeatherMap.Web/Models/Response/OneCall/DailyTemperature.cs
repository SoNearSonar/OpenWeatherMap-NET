using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class DailyTemperature
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("afternoon")]
        public double Afternoon { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("evening")]
        public double Eve { get; set; }

        [JsonProperty("morning")]
        public double Morning { get; set; }
    }
}
