using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollution
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("main")]
        public AirPollutionInfo PollutionInfo { get; set; }

        [JsonProperty("components")]
        public AirPollutionComponents PollutionComponents { get; set; }
    }
}
