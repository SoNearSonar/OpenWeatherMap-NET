using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum UnitsOfMeasurement
    {
        [EnumMember(Value = "standard")] Standard,
        [EnumMember(Value = "metric")] Metric,
        [EnumMember(Value = "imperial")] Imperial
    }
}
