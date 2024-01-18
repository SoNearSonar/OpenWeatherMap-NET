using System.Runtime.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public enum ExcludeData
    {
        [EnumMember(Value = "current")] Current,
        [EnumMember(Value = "minutely")] Minutely,
        [EnumMember(Value = "hourly")] Hourly,
        [EnumMember(Value = "daily")] Daily,
        [EnumMember(Value = "alerts")] Alerts
    }
}
