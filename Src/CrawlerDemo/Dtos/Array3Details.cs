using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CrawlerDemo.Dtos
{
    /// <summary>
    /// 组选3
    /// </summary>
    internal class Array3Details
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
        public string Amount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [JsonPropertyName("sort")]
        public int Sort { get; set; }



        /// <summary>
        /// 注数
        /// </summary>
        [JsonPropertyName("stakeCount")]
        public string LotterCount { get; set; }

        /// <summary>
        /// 中奖总金额 = Amount * Count
        /// </summary>
        [JsonPropertyName("totalPrizeamount")]
        public string TotalPrizeAmount { get; set; }
    }
}
