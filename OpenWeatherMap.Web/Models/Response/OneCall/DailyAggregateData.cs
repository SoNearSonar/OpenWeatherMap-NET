using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeatherMap.Web.Models
{
    public class DailyAggregateData
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("tz")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("units")]
        public UnitsOfMeasurement UnitsOfMeasurement { get; set; }

        [JsonProperty("cloud_cover")]
        public CloudCover CloudCover { get; set; }

        [JsonProperty("humidity")]
        public Humidity Humidity { get; set; }

        [JsonProperty("precipitation")]
        public Precipitation Precipitation { get; set; }

        [JsonProperty("temperature")]
        public DailyTemperature Temperature { get; set; }

        [JsonProperty("pressure")]
        public Pressure Pressure { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}
