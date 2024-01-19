﻿using OpenWeatherMap.Web.Models;
using OpenWeatherMap.Web.Converters;
using OpenWeatherMap.Web.Utilities;
using System.Text.Json;

namespace OpenWeatherMap.Web
{
    public class OpenWeatherMapClient
    {
        private readonly static string _oneCallUrl = "https://api.openweathermap.org/data/3.0/onecall";
        private readonly static string _airPollutionUrl = "http://api.openweathermap.org/data/2.5/air_pollution";
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
            string query = QueryUtility.GetWeatherQueryFromData(_oneCallUrl, _apiKey, latitude, longitude, excludedData, unitsOfMeasurement, language);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode) 
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WeatherData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<DateWeatherData> GetWeatherDataForDate(double latitude, double longitude, DateTime date, UnitsOfMeasurement unitsOfMeasurement = UnitsOfMeasurement.Standard, DataLanguage language = DataLanguage.English)
        {
            string urlPath = _oneCallUrl + "/timemachine";
            string query = QueryUtility.GetWeatherQueryForTimeFromData(urlPath, _apiKey, latitude, longitude, date, unitsOfMeasurement, language);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<DateWeatherData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<DailyAggregateData> GetDailyAggregateData(double latitude, double longitude, DateTime date, string timezone = "", UnitsOfMeasurement unitsOfMeasurement = UnitsOfMeasurement.Standard, DataLanguage language = DataLanguage.English)
        {
            string urlPath = _oneCallUrl + "/day_summary";
            string query = QueryUtility.GetDailyAggregateQueryFromData(urlPath, _apiKey, latitude, longitude, date, timezone, unitsOfMeasurement, language);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<DailyAggregateData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<AirPollutionData> GetCurrentAirPollutionData(double latitude, double longitude)
        {
            string query = QueryUtility.GetAirPollutionData(_airPollutionUrl, _apiKey, latitude, longitude);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<AirPollutionData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<AirPollutionData> GetForecastAirPollutionData(double latitude, double longitude)
        {
            string urlPath = _airPollutionUrl + "/forecast";
            string query = QueryUtility.GetAirPollutionData(urlPath, _apiKey, latitude, longitude);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<AirPollutionData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<AirPollutionData> GetHistoricalAirPollutionData(double latitude, double longitude, DateTime start, DateTime end)
        {
            string urlPath = _airPollutionUrl + "/history";
            string query = QueryUtility.GetHistoricalAirPollutionData(urlPath, _apiKey, latitude, longitude, start, end);

            var message = await _httpClient.GetAsync(query);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<AirPollutionData>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        internal T DeserializeObject<T>(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new DateTimeUnixConverter());
            options.Converters.Add(new DateTimeStringConverter());
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}