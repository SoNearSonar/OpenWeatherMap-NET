using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionData
    {
        [JsonPropertyName("coord")]
        public double[] Coordinates { get; set; } = default!;

        [JsonPropertyName("list")]
        public List<AirPollution> AirPollutionList { get; set; } = default!;
    }
}
