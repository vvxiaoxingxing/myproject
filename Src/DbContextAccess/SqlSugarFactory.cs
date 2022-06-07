using CrawlerCore.Options;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbContextAccess
{
    public class SqlSugarFactory
    {
        public SqlSugarClient DB { get; set; }

        private  DbType DBType { get; set; }
        private string DBConn { get; set; }
        public SqlSugarFactory(IOptions<DBOptions> dbOption)
        {
            if (dbOption.Value.DataBaseType == 1)
            {
                DBType = DbType.MySql;
                DBConn = dbOption.Value.MySqlStr;
            }
            else if (dbOption.Value.DataBaseType == 2)
            {
                DBType = DbType.SqlServer;
                DBConn = dbOption.Value.SqlServerStr;
            }
            DB = GetDB();
        }

        ///// <summary>
        ///// 返回SqlSugar数据库实例
        ///// </summary>
        ///// <param name="conn"></param>
        ///// <returns></returns>
        //private SqlSugarClient GetInstance(DbType dbType, string conn)
        //{
        //    //创建数据库对象
        //    return new SqlSugarClient(new ConnectionConfig()
        //    {
        //        ConnectionString = conn,//连接符字串
        //        DbType = dbType,// DbType.SqlServer,
        //        IsAutoCloseConnection = true,
        //        InitKeyType = InitKeyType.Attribute,//从特性读取主键自增信息
        //    });
        //}

        public  SqlSugarClient GetDB()
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
