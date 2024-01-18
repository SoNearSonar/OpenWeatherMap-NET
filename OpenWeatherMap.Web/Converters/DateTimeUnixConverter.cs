using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Web.Converters
{
    internal class DateTimeUnixConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(reader.GetInt64()).ToLocalTime();
            return dateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            DateTimeOffset time = value.ToUniversalTime();
            writer.WriteNumberValue(time.ToUnixTimeSeconds());
        }
    }
}
