using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ICrawlerService.Converter
{
    /// <summary>
    /// 数值序列化器
    /// </summary>
    public class IntJsonConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString().Replace(",", "");
            if (string.IsNullOrWhiteSpace(input))
            {
                return -1;
            }
            return Convert.ToInt32(input);
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            //if (value.HasValue)
            //{
            //    writer.WriteStringValue(value.ToString());
            //}
            //else
            //{
            //    writer.WriteStringValue(string.Empty);
            //}
            writer.WriteStringValue(value.ToString());
        }
    }
}
