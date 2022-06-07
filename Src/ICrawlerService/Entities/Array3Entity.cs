using ICrawlerService.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ICrawlerService.Entities
{
    public class Array3Entity
    {
        /// <summary>
        /// 期号
        /// </summary>
        [JsonPropertyName("lotteryDrawNum")]
        public string LotterNo { get; set; }

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
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? SaleBeginTime { get; set; }

        /// <summary>
        /// 彩票截止销售时间
        /// </summary>
        [JsonPropertyName("lotterySaleEndtime")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? SaleEndtime { get; set; }

        /// <summary>
        /// 兑奖开始时间
        /// </summary>
        [JsonPropertyName("lotteryPaidBeginTime")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? PaidBeginTime { get; set; }
        /// <summary>
        /// 兑奖 截止时间
        /// </summary>
        [JsonPropertyName("lotteryPaidEndTime")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? PaidEndTime { get; set; }

        /// <summary>
        /// 总销售额
        /// </summary>
        [JsonPropertyName("totalSaleAmount")]
        [JsonConverter(typeof(LongJsonConverter))]
        public long TotalSaleAmount { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        [JsonPropertyName("prizeLevelList")]
        public List<Array3DetailsEntity> Details { get; set; }

    }
}
