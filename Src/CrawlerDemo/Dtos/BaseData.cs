using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CrawlerDemo.Dtos
{
    internal class BaseData<T>
    {
        [JsonPropertyName("dataFrom")]
        public string DataFrom { get; set; }

        [JsonPropertyName("emptyFlag")]
        public bool EmptyFlag { get; set; }

        /// <summary>
        /// 错误编号 0 请求成功
        /// </summary>
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonPropertyName("value")]
        public T Result { get; set; }


    }
}
