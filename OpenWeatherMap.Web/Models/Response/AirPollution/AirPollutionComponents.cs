using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionComponents
    {
        [JsonPropertyName("co")]
        public double CarbonMonoxide { get; set; } = default!;

        [JsonPropertyName("no")]
        public double NitrogenMonoxide { get; set; } = default!;

        [JsonPropertyName("no2")]
        public double NitrogenDioxide { get; set; } = default!;

        [JsonPropertyName("o3")]
        public double Ozone { get; set; } = default!;

        [JsonPropertyName("so2")]
        public double SulphurDioxide { get; set; } = default!;

        [JsonPropertyName("pm2_5")]
        public double FineParticulateMatter { get; set; } = default!;

        [JsonPropertyName("pm10")]
        public double CoarseParticulateMatter { get; set; } = default!;

        [JsonPropertyName("nh3")]
        public double Ammonia { get; set; } = default!;

    }
}
