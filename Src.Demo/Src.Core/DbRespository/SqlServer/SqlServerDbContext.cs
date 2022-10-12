using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src.Core.DbRespository.SqlServer
{
    public class SqlServerDbContext
    {
        private const string dbstr = "Data Source=139.196.55.190;Initial Catalog=WxGroupDb;uid=csm_db_admin;pwd=sdmp2099$;MultipleActiveResultSets=True;";

        public SqlSugarClient DB { get; set; }

        private DbType DBType { get; set; }
        private string DBConn { get; set; }
        public SqlServerDbContext()
        {
            DBType = DbType.SqlServer;
            DBConn = dbstr;
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
