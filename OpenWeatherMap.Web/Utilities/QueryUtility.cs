using OpenWeatherMap.Web.Extensions;
using OpenWeatherMap.Web.Models;
using System.Text;

namespace OpenWeatherMap.Web.Utilities
{
    internal static class QueryUtility
    {
        internal static string GetWeatherQueryFromData(string url, string apiKey, double latitude, double longitude, ExcludeData[] excludedData, UnitsOfMeasurement unitsOfMeasurement, DataLanguage language)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(apiKey);
            sb.Append("&units=");
            sb.Append(unitsOfMeasurement.GetEnumMemberValue().ToLowerInvariant());
            sb.Append("&lang=");
            sb.Append(language.GetEnumMemberValue().ToLowerInvariant());

            if (excludedData != null && excludedData.Length != 0)
            {
                sb.Append("&exclude=");
                foreach (var excludeData in excludedData)
                {
                    sb.Append(excludeData.ToString().ToLowerInvariant());
                    sb.Append(',');
                }

                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        internal static string GetWeatherQueryForTimeFromData(string url, string apiKey, double latitude, double longitude, DateTime date, UnitsOfMeasurement unitsOfMeasurement, DataLanguage language)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(apiKey);
            sb.Append("&units=");
            sb.Append(unitsOfMeasurement.GetEnumMemberValue().ToLowerInvariant());
            sb.Append("&lang=");
            sb.Append(language.GetEnumMemberValue().ToLowerInvariant());
            sb.Append("&dt=");

            long unixTime = ((DateTimeOffset)date).ToUnixTimeSeconds();
            sb.Append(unixTime);

            return sb.ToString();
        }

        internal static string GetDailyAggregateQueryFromData(string url, string apiKey, double latitude, double longitude, DateTime date, string timezone, UnitsOfMeasurement unitsOfMeasurement, DataLanguage language)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(apiKey);
            sb.Append("&date=");
            sb.Append(date.ToString("yyyy-MM-dd"));
            sb.Append("&units=");
            sb.Append(unitsOfMeasurement.GetEnumMemberValue().ToLowerInvariant());
            sb.Append("&lang=");
            sb.Append(language.GetEnumMemberValue().ToLowerInvariant());

            if (!string.IsNullOrWhiteSpace(timezone))
            {
                sb.Append("&tz=");
                sb.Append(timezone);
            }

            return sb.ToString();
        }
    }
}
