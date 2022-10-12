using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Src.Core.DbRespository.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ExcelCompareApp
{
    public class ExcelService
    {
        public void ExceExcel()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", $"0609.xlsx");
            DataTable excel = ExcelToDataTable(workbook, path);

            for (int j = 0; j < excel.Rows.Count; j++)
            {
                var item = excel.Rows[j];
                string groupname = item["所在社群"].ToString();
                string msgtime = item["聊天时间"].ToString();
                string content = item["聊天内容"].ToString();
                string nickname = item["昵称"].ToString();
                string wechatid = item["微信号"].ToString();
                string points = item["积分明细"].ToString();
                AddPoints(groupname, nickname, msgtime, content, wechatid, Convert.ToInt32(points));
            }
        }

        public static bool IsExist(string wechatId,string nickName)
        {
            var sql = $"select top 1 1 from job_wx_members_info where wechat_id=@wechatId And nick_name=@nickName";
            var param = new {
                wechatId = wechatId,
                nickName = nickName
            };
            var db = new SqlServerDbContext().GetDB();
            var result = db.Ado.SqlQuerySingle<int?>(sql,param);
            if (result == null || result <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool AddMembersInfo(string wechatId, string nickName, string hospital, string doctorName, string entComName,string excelDesc)
        {
            var db = new SqlServerDbContext().GetDB();
            //新增
            string sql = "insert into job_wx_members_info(wechat_id, nick_name, hospital, doctor_name, ent_com_name,excel_desc) values(@wechatId,@nickName,@hospital,@doctorName,@entComName,@excelDesc)";
            var param = new
            {
                wechatId = wechatId,
                nickName = nickName,
                hospital = hospital,
                doctorName = doctorName,
                entComName = entComName,
                excelDesc = excelDesc
            };
            return db.Ado.ExecuteCommand(sql,param) > 0;
        }


        public static bool AddPoints(string groupname, string nickname, string msgtime, string msgcontent, string wechatid,int points)
        {
            var db = new SqlServerDbContext().GetDB();
            //新增
            string sql = @"insert into z_tem_0609_points(groupname, msgtime, msgcontent, nickname, wechatid, points) 
                                                values(@groupname,@msgtime,@msgcontent,@nickname,@wechatid,@points)";
            var param = new
            {
                groupname = groupname,
                msgtime = msgtime,
                msgcontent = msgcontent,
                wechatid = wechatid,
                nickname = nickname,
                points = points,
            };
            return db.Ado.ExecuteCommand(sql, param) > 0;
        }




        /// <summary>
        /// excel转datatable
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(XSSFWorkbook workbook,string path)
        {
            try
            {
                DataTable dt = new DataTable();
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate,FileAccess.ReadWrite);
                IWorkbook wk = null;
                var isxls = path.EndsWith(".xls");
                if (isxls)
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }
                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(0);


                //获取Excel的最大列数
                int colsCount = sheet.GetRow(0).LastCellNum;
                for (int i = 0; i < colsCount; i++)
                {
                    //将第一列设置成表头
                    dt.Columns.Add(sheet.GetRow(0).GetCell(i).ToString());
                }

                //获取Excel的最大行数数
                int rowsCount = sheet.PhysicalNumberOfRows;
                for (int x = 1; x < rowsCount; x++)
                {
                    if (sheet.GetRow(x) != null)
                    {
                        DataRow dr = dt.NewRow();
                        for (int y = 0; y < colsCount; y++)
                        {
                            dr[y] = sheet.GetRow(x).GetCell(y)?.ToString() ?? "";
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
}
}
