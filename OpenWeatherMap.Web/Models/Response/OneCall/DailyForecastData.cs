using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class DailyForecastData : IGeneralForecastData, ISpecificForecastData
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime DateTime { get; set; } = default!;

        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime Sunrise { get; set; } = default!;

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime Sunset { get; set; } = default!;

        [JsonPropertyName("moonrise")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime Moonrise { get; set; } = default!;

        [JsonPropertyName("moonset")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime MoonSet { get; set; } = default!;

        [JsonPropertyName("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = default!;

        [JsonPropertyName("temp")]
        public WeatherTemperature Temperature { get; set; } = default!;

        [JsonPropertyName("feels_like")]
        public WeatherFeelsLike FeelsLike { get; set; } = default!;

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegrees { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; } = default!;

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; } = default!;

        [JsonPropertyName("clouds")]
        public int CloudCoverage { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; }

        [JsonPropertyName("uvi")]
        public double UVIndex { get; set; }

        [JsonPropertyName("rain")]
        public double Rain { get; set; } = default!;

        [JsonPropertyName("snow")]
        public double Snow { get; set; } = default!;
    }
}
