using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ICrawlerService.Converter
{
    public class DateTimeJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString();
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            return DateTime.Parse(input);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}
