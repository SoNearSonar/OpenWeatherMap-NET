using OpenWeatherMap.Web.Models;
using OpenWeatherMap.Web.Converters;
using OpenWeatherMap.Web.Extensions;
using System.Text;
using System.Text.Json;

namespace OpenWeatherMap.Web
{
    public class OpenWeatherMapClient
    {
        private readonly static string _url = "https://api.openweathermap.org/data/3.0/onecall";
        private readonly string _apiKey = string.Empty;
        private static HttpClient _httpClient;

        public OpenWeatherMapClient(string apiKey)
        { 
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "OpenWeatherMap-NET/1.0");
            _apiKey = apiKey;
        }

        public async Task<WeatherData> GetWeatherData(double latitude, double longitude, ExcludeData[] excludedData = null, UnitsOfMeasurement unitsOfMeasurement = UnitsOfMeasurement.Standard, DataLanguage language = DataLanguage.English)
        {
            string query = GetWeatherQueryFromData(latitude, longitude, excludedData, unitsOfMeasurement, language);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode) 
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WeatherData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<DailyAggregateData> GetDailyAggregateData(double latitude, double longitude, DateTime date, string timezone = "", UnitsOfMeasurement unitsOfMeasurement = UnitsOfMeasurement.Standard, DataLanguage language = DataLanguage.English)
        {
            string query = GetDailyAggregateQueryFromData(latitude, longitude, date, timezone, unitsOfMeasurement, language);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<DailyAggregateData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public T DeserializeObject<T>(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new DateTimeUnixConverter());
            options.Converters.Add(new DateTimeStringConverter());
            return JsonSerializer.Deserialize<T>(json, options);
        }

        private string GetWeatherQueryFromData(double latitude, double longitude, ExcludeData[] excludedData, UnitsOfMeasurement unitsOfMeasurement, DataLanguage language)
        {
            StringBuilder sb = new StringBuilder(_url);
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(_apiKey);
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

        private string GetDailyAggregateQueryFromData(double latitude, double longitude, DateTime date, string timezone, UnitsOfMeasurement unitsOfMeasurement, DataLanguage language)
        {
            StringBuilder sb = new StringBuilder(_url);
            sb.Append("/day_summary");
            sb.Append("?lat=");
            sb.Append(latitude);
            sb.Append("&lon=");
            sb.Append(longitude);
            sb.Append("&appid=");
            sb.Append(_apiKey);
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