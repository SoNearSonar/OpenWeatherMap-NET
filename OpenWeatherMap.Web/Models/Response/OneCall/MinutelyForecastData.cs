using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeatherMap.Web.Models
{
    public class MinutelyForecastData : IGeneralForecastData
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("precipitation")]
        public double Precipitation { get; set; }
    }
}
