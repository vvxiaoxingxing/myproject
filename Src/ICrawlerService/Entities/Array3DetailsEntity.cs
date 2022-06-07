using ICrawlerService.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ICrawlerService.Entities
{
    /// <summary>
    /// 组选3
    /// </summary>
    public class Array3DetailsEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [JsonPropertyName("prizeLevel")]
        public string Name { get; set; }

        /// <summary>
        /// 奖金
        /// </summary>
        [JsonPropertyName("stakeAmount")]
        [JsonConverter(typeof(LongJsonConverter))]
        public long Amount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [JsonPropertyName("sort")]
        public int Sort { get; set; }



        /// <summary>
        /// 注数
        /// </summary>
        [JsonPropertyName("stakeCount")]
        [JsonConverter(typeof(IntJsonConverter))]
        public int LotterCount { get; set; }

        /// <summary>
        /// 中奖总金额 = Amount * Count
        /// </summary>
        [JsonPropertyName("totalPrizeamount")]
        [JsonConverter(typeof(LongJsonConverter))]
        public long TotalPrizeAmount { get; set; }
    }
}
