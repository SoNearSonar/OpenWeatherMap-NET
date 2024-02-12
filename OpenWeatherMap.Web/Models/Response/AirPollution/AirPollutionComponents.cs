using Newtonsoft.Json;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionComponents
    {
        [JsonProperty("co")]
        public double CarbonMonoxide { get; set; }

        [JsonProperty("no")]
        public double NitrogenMonoxide { get; set; }

        [JsonProperty("no2")]
        public double NitrogenDioxide { get; set; }

        [JsonProperty("o3")]
        public double Ozone { get; set; }

        [JsonProperty("so2")]
        public double SulphurDioxide { get; set; }

        [JsonProperty("pm2_5")]
        public double FineParticulateMatter { get; set; }

        [JsonProperty("pm10")]
        public double CoarseParticulateMatter { get; set; }

        [JsonProperty("nh3")]
        public double Ammonia { get; set; }

    }
}
