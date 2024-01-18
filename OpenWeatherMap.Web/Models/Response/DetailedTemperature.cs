﻿using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class DetailedTemperature : IDetailedItem
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }

        [JsonPropertyName("min")]
        public double Min { get; set; }

        [JsonPropertyName("max")]
        public double Max { get; set; }

        [JsonPropertyName("night")]
        public double Night { get; set; }

        [JsonPropertyName("eve")]
        public double Eve { get; set; }

        [JsonPropertyName("morn")]
        public double Morning { get; set; }

    }
}