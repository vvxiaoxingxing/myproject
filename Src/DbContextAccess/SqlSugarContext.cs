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

namespace DbContextAccess
{
    public class SqlSugarContext
    {
        public SqlSugarClient DB {
            get;set;
        }

        public SqlSugarContext()
        {

        }
        
    }
}
