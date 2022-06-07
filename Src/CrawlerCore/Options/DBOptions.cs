using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerCore.Options
{
    public class DBOptions
    {
        /// <summary>
        /// mysql 地址
        /// </summary>
        public string MySqlStr { get; set; }
        public string SqlServerStr { get; set; }

        /// <summary>
        /// 当前使用数据库类型
        /// 1：mysql
        /// 2：sqlserver
        /// </summary>
        public int DataBaseType { get; set; }
    }
}
