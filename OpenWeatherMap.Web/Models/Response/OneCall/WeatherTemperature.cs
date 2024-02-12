using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class WeatherTemperature : IDetailedItem
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morning { get; set; }

    }
}
