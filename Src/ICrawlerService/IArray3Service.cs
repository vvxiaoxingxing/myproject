using ICrawlerService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICrawlerService
{
    /// <summary>
    /// 排列3 接口层
    /// </summary>
    public interface IArray3Service
    {
        /// <summary>
        /// 保存排列三的数据
        /// </summary>
        /// <returns></returns>
        Task SaveArray3InfoAsync();

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<List<Array3RespDtos>> GetArray3InfoAsync(int PageSize);

        Task<Array3AnalysisRspDto> GetArray3AnalysisAsync(string lotterNo,int count);




    }
}
