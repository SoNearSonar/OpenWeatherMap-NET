using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Models
{
    public class Alert
    {
        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; } = default!;

        [JsonPropertyName("event")]
        public string Event { get; set; } = default!;

        [JsonPropertyName("start")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime Started { get; set; } = default!;

        [JsonPropertyName("end")]
        [JsonConverter(typeof(Converters.DateTimeUnixConverter))]
        public DateTime Ended { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = default!;
    }
}
