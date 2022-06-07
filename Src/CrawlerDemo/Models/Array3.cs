using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrawlerDemo.Models
{

    internal class Array3
    {
        /// <summary>
        /// 期号
        /// </summary>
        [JsonPropertyName("lotteryDrawNum")]
        public string No { get; set; }

        /// <summary>
        /// 开奖日期
        /// </summary>
        [JsonPropertyName("lotteryDrawTime")]
        public string DrawDate { get; set; }

        /// <summary>
        /// 开奖结果
        /// </summary>
        [JsonPropertyName("lotteryDrawResult")]
        public string DrawResult { get; set; }

        /// <summary>
        /// 彩票开始销售时间
        /// </summary>
        [JsonPropertyName("lotterySaleBeginTime")]
        public string SaleBeginTime { get; set; }

        /// <summary>
        /// 彩票截止销售时间
        /// </summary>
        [JsonPropertyName("lotterySaleEndtime")]
        public string SaleEndtime { get; set; }

        /// <summary>
        /// 兑奖开始时间
        /// </summary>
        [JsonPropertyName("lotteryPaidBeginTime")]
        public string PaidBeginTime { get; set; }
        /// <summary>
        /// 兑奖 截止时间
        /// </summary>
        [JsonPropertyName("lotteryPaidEndTime")]
        public string PaidEndTime { get; set; }

        /// <summary>
        /// 总销售额
        /// </summary>
        [JsonPropertyName("totalSaleAmount")]
        public string TotalSaleAmount { get; set; }

    }
}
