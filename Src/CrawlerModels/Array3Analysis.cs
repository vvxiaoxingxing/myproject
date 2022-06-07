using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerModels
{
    [SugarTable("l_array3_analysis")]
    public class Array3Analysis
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public int No1 { get; set; }
        public int No2 { get; set; }
        public int No3 { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        public string LotterNo { get; set; }

        /// <summary>
        /// 开奖日期
        /// </summary>
        public DateTime? DrawDate { get; set; }
    }
}
