using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace OpenWeatherMap.Web.Models
{
    public class DailyForecastData : IGeneralForecastData, ISpecificForecastData
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonProperty("moonrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Moonrise { get; set; }

        [JsonProperty("moonset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime MoonSet { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("temp")]
        public WeatherTemperature Temperature { get; set; }

        [JsonProperty("feels_like")]
        public WeatherFeelsLike FeelsLike { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public int WindDegrees { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public int CloudCoverage { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("uvi")]
        public double UVIndex { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }

        [JsonProperty("snow")]
        public double Snow { get; set; }
    }
}
