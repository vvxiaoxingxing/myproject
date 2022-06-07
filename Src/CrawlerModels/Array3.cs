using System;
using SqlSugar;

namespace CrawlerModels
{
    [SugarTable("l_array3")]
    public class Array3
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        public string LotterNo { get; set; }

        /// <summary>
        /// 开奖日期
        /// </summary>
        public string DrawDate { get; set; }

        /// <summary>
        /// 开奖结果
        /// </summary>
        public string DrawResult { get; set; }

        /// <summary>
        /// 彩票开始销售时间
        /// </summary>
        public DateTime? SaleBeginTime { get; set; }

        /// <summary>
        /// 彩票截止销售时间
        /// </summary>
        public DateTime? SaleEndtime { get; set; }

        /// <summary>
        /// 兑奖开始时间
        /// </summary>
        public DateTime? PaidBeginTime { get; set; }
        /// <summary>
        /// 兑奖 截止时间
        /// </summary>
        public DateTime? PaidEndTime { get; set; }

        /// <summary>
        /// 总销售额
        /// </summary>
        public long TotalSaleAmount { get; set; }

        #region 直选3
        /// <summary>
        /// 直选名称
        /// </summary>
        public string ZhiName { get; set; }

        /// <summary>
        /// 直选奖金
        /// </summary>
        public long ZhiAmount { get; set; }

        /// <summary>
        /// 直选中奖注数
        /// </summary>
        public int ZhiLotterCount { get; set; }

        /// <summary>
        /// 中奖总金额 = Amount * Count
        /// </summary>
        public long ZhiTotalPrizeAmount { get; set; }
        #endregion

        #region 组选3
        /// <summary>
        /// 直选名称
        /// </summary>
        public string Group3Name { get; set; }

        /// <summary>
        /// 直选奖金
        /// </summary>
        public long Group3Amount { get; set; }

        /// <summary>
        /// 直选中奖注数
        /// </summary>
        public int Group3LotterCount { get; set; }
        /// <summary>
        /// 中奖总金额 = Amount * Count
        /// </summary>
        public long Group3TotalPrizeAmount { get; set; }
        #endregion

        #region 组选6
        /// <summary>
        /// 直选名称
        /// </summary>
        public string Group6Name { get; set; }

        /// <summary>
        /// 直选奖金
        /// </summary>
        public long Group6Amount { get; set; }

        /// <summary>
        /// 直选中奖注数
        /// </summary>
        public int Group6LotterCount { get; set; }

        /// <summary>
        /// 中奖总金额 = Amount * Count
        /// </summary>
        public long Group6TotalPrizeAmount { get; set; }
        #endregion


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
