using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class DailyForecastData : IGeneralForecastData, ISpecificForecastData
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(Converters.DateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(Converters.DateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(Converters.DateTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        [JsonConverter(typeof(Converters.DateTimeConverter))]
        public DateTime Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        [JsonConverter(typeof(Converters.DateTimeConverter))]
        public DateTime MoonSet { get; set; }

        [JsonPropertyName("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("temp")]
        public DetailedTemperature Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public DetailedFeelsLike FeelsLike { get; set; }

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
        public double WindGust { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("clouds")]
        public double Clouds { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; }

        [JsonPropertyName("uvi")]
        public double UVIndex { get; set; }
    }
}
