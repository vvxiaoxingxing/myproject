using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CrawlerDemo.Dtos
{
    /// <summary>
    /// 排列类型 彩票
    /// </summary>
    internal class LotteryArray : BaseData<LotteryArray>
    {
        [JsonPropertyName("list")]
        public List<Array3> Data { get; set; }

        [JsonPropertyName("pageNo")]
        public int PageIndex { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    
}
