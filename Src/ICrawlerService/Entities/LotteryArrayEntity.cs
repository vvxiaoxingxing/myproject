using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ICrawlerService.Entities
{
    /// <summary>
    /// 排列类型 彩票
    /// </summary>
    public class LotteryArrayEntity : BaseData<LotteryArrayEntity>
    {
        [JsonPropertyName("list")]
        public List<Array3Entity> Data { get; set; }

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
