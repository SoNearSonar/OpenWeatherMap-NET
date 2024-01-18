using System.Runtime.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public enum UnitsOfMeasurement
    {
        [EnumMember(Value = "standard")] Standard,
        [EnumMember(Value = "metric")] Metric,
        [EnumMember(Value = "imperial")] Imperial
    }
}
