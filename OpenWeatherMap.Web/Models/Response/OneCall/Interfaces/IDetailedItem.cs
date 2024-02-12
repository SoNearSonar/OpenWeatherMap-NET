using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public interface IDetailedItem
    {
        [JsonProperty("day")]
        double Day { get; set; }

        [JsonProperty("night")]
        double Night { get; set; }

        [JsonProperty("eve")]
        double Eve { get; set; }

        [JsonProperty("morn")]
        double Morning { get; set; }
    }
}
