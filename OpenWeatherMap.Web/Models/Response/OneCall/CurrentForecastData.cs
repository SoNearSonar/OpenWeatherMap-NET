﻿using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class CurrentForecastData : IGeneralForecastData, ISpecificForecastData
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

        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        public double UVIndex { get; set; }

        [JsonPropertyName("clouds")]
        public int CloudCoverage { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegrees { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; } = default!;

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; } = default!;

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; } = default!;

        [JsonPropertyName("snow")]
        public Snow Snow { get; set; } = default!;
    }
}