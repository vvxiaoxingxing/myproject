using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Src.Core.DbRespository;
using Src.Core.DbRespository.MySql;
using Src.Core.DbRespository.SqlServer;
using System;
using System.Text.RegularExpressions;

namespace ExcelCompareApp
{
    class Program
    {
        static void Main(string[] args)
        {


            string str = "nihao:23wqeq:dsfasdfasdf:asdfasdfasdf";

            Regex regex = new Regex(@"^(?<userName>[^\:\<]+)[:]");
            Match match = regex.Match(str);
            if (match.Success)
            {
                string result1 = match.Groups["userName"].Value;
            }





            //string result = new EntComService().GetNickNameByWechatId();
            //string result = new EntComService().GetNickName();
            //Console.WriteLine(result);

            //new ExcelService().ExceExcel();
        }

        public void ResService()
        {
            
        }
    }
}
