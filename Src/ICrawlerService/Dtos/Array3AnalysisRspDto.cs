using CrawlerModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICrawlerService.Dtos
{
    public class Array3AnalysisRspDto
    {
        /// <summary>
        /// 本期开奖结果
        /// </summary>
        public Array3 LocalArray3Data { get; set; }
        /// <summary>
        /// 每个球近期出现的次数
        /// </summary>
        public Arr3AnalysisEveryBallCount EveryBallCount { get; set; }
        public Arr3AnalysisEveryBallCount EveryBallNextCount { get; set; }
    }

    public class Arr3AnalysisEveryBallCount {
        /// <summary>
        /// 每个球近期出现的次数
        /// </summary>
        public Array3Ball No1Count { get; set; }
        public Array3Ball No2Count { get; set; }
        public Array3Ball No3Count { get; set; }
    }

    public class Array3Ball {
        public int Num0 { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
        public int Num5 { get; set; }
        public int Num6 { get; set; }
        public int Num7 { get; set; }
        public int Num8 { get; set; }
        public int Num9 { get; set; }
    }
}
