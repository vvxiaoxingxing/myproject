using NetCore.Infrastructure.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NetCore.Infrastructure.Utils
{
    public static class JsonSerializerUtility
    {
        /// <summary>
        /// 是否启用属性大写操作
        /// </summary>
        //internal static bool EnabledPascalPropertyNaming = false;

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static string Serialize(object obj, JsonSerializerOptions jsonSerializerOptions = default)
        {
            return JsonSerializer.Serialize(obj, jsonSerializerOptions ?? GetDefaultJsonSerializerOptions());
        }
        /// <summary>
        /// 转义并序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string EscSerialize(object obj)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            return JsonSerializer.Serialize(obj, jsonSerializerOptions ?? GetDefaultJsonSerializerOptions());
        }
        /// <summary>  
        /// 转换输入字符串中的任何转义字符。如：Unicode 的中文 \u8be5  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static string UnicodeDencode(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            return Regex.Unescape(str);
        }
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonSerializerOptions jsonSerializerOptions = default)
        {
            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions ?? GetDefaultJsonSerializerOptions());
        }
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonSerializerOptions jsonSerializerOptions = default)
        {
            return JsonSerializer.Deserialize(json, type, jsonSerializerOptions ?? GetDefaultJsonSerializerOptions());
        }


        /// <summary>
        /// 获取默认 JSON 序列化选项
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerOptions GetDefaultJsonSerializerOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                //IgnoreNullValues = true,
                WriteIndented = true,
                PropertyNamingPolicy = null,
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)//解决json转换 unicode 乱码问题
                //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                //PropertyNamingPolicy = new NamingPolicy()
            };

            //if (EnabledPascalPropertyNaming)
            //{
            //    jsonSerializerOptions.PropertyNamingPolicy = null;
            //}
            jsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss"));

            return jsonSerializerOptions;
        }

    }
}
