using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeatherMap.Web.Models
{
    public class AirPollutionData
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("list")]
        public List<AirPollution> AirPollutionList { get; set; }
    }
}
