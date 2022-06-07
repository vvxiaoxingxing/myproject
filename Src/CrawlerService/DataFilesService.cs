using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerService
{
    /// <summary>
    /// 请求回来的数据存储到文件中去
    /// </summary>
    public class DataFilesService
    {
        /// <summary>
        /// 保存到txt文本中去
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="folderName">w文件夹名称</param>
        /// <param name="name">名称</param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static async Task SaveHtml(string content,string folderName, string name)
        {
            try
            {
                //文件夹 路径
                string folderPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", folderName);
                // 文件路径
                string filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", folderName, $"{name}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);//创建文件夹
                }
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();//创建文件
                }

                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                using (StreamWriter file = new StreamWriter(fileStream))
                {
                     file.Write(content);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
