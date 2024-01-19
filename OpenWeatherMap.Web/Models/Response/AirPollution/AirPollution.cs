using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollution
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime DateTime { get; set; } = default!;

        [JsonPropertyName("main")]
        public AirPollutionInfo PollutionInfo { get; set; } = default!;

        [JsonPropertyName("components")]
        public AirPollutionComponents PollutionComponents { get; set; } = default!;
    }
}
