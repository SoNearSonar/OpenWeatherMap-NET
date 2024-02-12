using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace OpenWeatherMap.Web.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitsOfMeasurement
    {
        [EnumMember(Value = "standard")] Standard,
        [EnumMember(Value = "metric")] Metric,
        [EnumMember(Value = "imperial")] Imperial
    }
}
