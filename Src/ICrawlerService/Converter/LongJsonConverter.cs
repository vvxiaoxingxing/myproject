using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ICrawlerService.Converter
{
    public class LongJsonConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString().Replace(",", "");
            if (string.IsNullOrWhiteSpace(input))
            {
                return -1;
            }
            return Convert.ToInt64(input);
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
