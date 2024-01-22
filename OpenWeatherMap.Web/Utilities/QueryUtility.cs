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

        internal static string GetAirPollutionData(string url, string apiKey, double latitude, double longitude)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(apiKey);
            return sb.ToString();
        }

        internal static string GetHistoricalAirPollutionData(string url, string apiKey, double latitude, double longitude, DateTime start, DateTime end)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(apiKey);

            sb.Append("&start=");
            long startUnixTime = ((DateTimeOffset)start).ToUnixTimeSeconds();
            sb.Append(startUnixTime);

            sb.Append("&end=");
            long endUnixTime = ((DateTimeOffset)end).ToUnixTimeSeconds();
            sb.Append(endUnixTime);

            return sb.ToString();
        }

        internal static string GetCoordinatesFromLocationData(string _url, string apiKey, string location)
        {
            StringBuilder sb = new StringBuilder(_url);
            sb.Append("?q=");
            sb.Append(location);
            sb.Append("&limit=1");
            sb.Append("&appid=");
            sb.Append(apiKey);

            return sb.ToString();
        }
    }
}
