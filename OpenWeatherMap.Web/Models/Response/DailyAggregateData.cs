using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class DailyAggregateData
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz")]
        public string Timezone { get; set; } = default!;

        [JsonPropertyName("date")]
        [JsonConverter(typeof(Converters.DateTimeStringConverter))]
        public DateTime Date { get; set; } = default!;

        [JsonPropertyName("units")]
        public UnitsOfMeasurement UnitsOfMeasurement { get; set; } = default!;

        [JsonPropertyName("cloud_cover")]
        public CloudCover CloudCover { get; set; } = default!;

        [JsonPropertyName("humidity")]
        public Humidity Humidity { get; set; } = default!;

        [JsonPropertyName("temperature")]
        public DailyTemperature Temperature { get; set; } = default!;

        [JsonPropertyName("pressure")]
        public Pressure Pressure { get; set; } = default!;

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = default!;
    }
}
