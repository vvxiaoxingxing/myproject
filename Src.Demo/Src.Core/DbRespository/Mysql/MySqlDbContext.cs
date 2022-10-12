using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src.Core.DbRespository.MySql
{
    public class MySqlDbContext
    {
        public SqlSugarClient DB { get; set; }

        private DbType DBType { get; set; }
        private string DBConn { get; set; }
        public MySqlDbContext(IOptions<DBOptions> dbOption)
        {
            DBType = DbType.MySql;
            DBConn = dbOption.Value.MySqlStr;
            DB = GetDB();
        }

        public SqlSugarClient GetDB()
        {
            //创建数据库对象
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DBConn,//连接符字串
                DbType = DBType,// DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键自增信息
            });
        }

    }
}
