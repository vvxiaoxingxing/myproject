using CrawlerCore.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DbContext.MySql
{
    public class BaseMySqlContext
    {
        public SqlSugarClient DB { get; set; }
        public BaseMySqlContext(IOptions<DBOptions> dbOption, int userId)
        {
            if (dbOption.Value.DataBaseType == 1)
            {
                this.DB = SqlSugarFactory.GetDB(DbType.MySql, dbOption.Value.MySqlStr);
            }
            else if (dbOption.Value.DataBaseType == 2)
            {
                this.DB = SqlSugarFactory.GetDB(DbType.SqlServer, dbOption.Value.MySqlStr);
            }
        }
    }
}
