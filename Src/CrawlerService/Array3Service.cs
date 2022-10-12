using AutoMapper;
using CrawlerCore.Http;
using CrawlerCore.Options;
using CrawlerModels;
using CrawlerService.AutoMapperService;
using DbContextAccess;
using ICrawlerService;
using ICrawlerService.Dtos;
using ICrawlerService.Entities;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrawlerService
{
    public class Array3Service :  IArray3Service
    {
        public readonly IMapper _mapper;
        public readonly SqlSugarFactory _db;


        public Array3Service(IMapper mapper,
            SqlSugarFactory db)
        {
            _mapper = mapper;
            _db = db;
        }

        /// <summary>
        /// 获取排列数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<List<Array3RespDtos>> GetArray3InfoAsync(int PageSize)
        {
            var data = await _db.DB.Queryable<Array3>()
                .Select<Array3RespDtos>()
                .OrderBy(i => i.CreateTime, OrderByType.Desc)
                .Take(PageSize)
                .ToListAsync();
            return data;
        }
        #region 分析排列3
        /// <summary>
        /// 获取排列3开奖结果的分析，默认以100期为参考
        /// </summary>
        /// <param name="lotterNo"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Array3AnalysisRspDto> GetArray3AnalysisAsync(string lotterNo, int count = 100)
        {
            try
            {
                var lotterData = await _db.DB.Queryable<Array3>().Where(i => i.LotterNo == lotterNo).FirstAsync();
                var etime = Convert.ToDateTime(lotterData.DrawDate);
                //获取两年的数据
                //1.计算这个数字不同时期出现的次数=默认100期
                //倒叙 获取这个时间段的 开奖记录 用于解析
                var analysisData = await _db.DB.Queryable<Array3Analysis>()
                    .Where(i => i.DrawDate < etime)
                    .OrderBy(i => i.DrawDate, OrderByType.Desc)
                    .Take(100)
                    .ToListAsync();
                Array3AnalysisRspDto result = new Array3AnalysisRspDto();
                result.LocalArray3Data = lotterData;
                result.EveryBallCount = await GetEveryBallsCountAsync(analysisData);
                result.EveryBallNextCount = await GetArray3NextCountAsync(lotterData.DrawResult, analysisData);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        #region 最近开奖出现次数详情
        private async Task<Arr3AnalysisEveryBallCount> GetEveryBallsCountAsync(List<Array3Analysis> data)
        {
            Arr3AnalysisEveryBallCount result = new Arr3AnalysisEveryBallCount();
            #region No1
            Array3Ball ballNo1 = new Array3Ball();
            ballNo1.Num0 = data.Where(i => i.No1 == 0).ToList().Count;
            ballNo1.Num1 = data.Where(i => i.No1 == 1).ToList().Count;
            ballNo1.Num2 = data.Where(i => i.No1 == 2).ToList().Count;
            ballNo1.Num3 = data.Where(i => i.No1 == 3).ToList().Count;
            ballNo1.Num4 = data.Where(i => i.No1 == 4).ToList().Count;
            ballNo1.Num5 = data.Where(i => i.No1 == 5).ToList().Count;
            ballNo1.Num6 = data.Where(i => i.No1 == 6).ToList().Count;
            ballNo1.Num7 = data.Where(i => i.No1 == 7).ToList().Count;
            ballNo1.Num8 = data.Where(i => i.No1 == 8).ToList().Count;
            ballNo1.Num9 = data.Where(i => i.No1 == 9).ToList().Count;
            result.No1Count = ballNo1;
            #endregion

            #region No2
            Array3Ball ballNo2 = new Array3Ball();
            ballNo2.Num0 = data.Where(i => i.No2 == 0).ToList().Count;
            ballNo2.Num1 = data.Where(i => i.No2 == 1).ToList().Count;
            ballNo2.Num2 = data.Where(i => i.No2 == 2).ToList().Count;
            ballNo2.Num3 = data.Where(i => i.No2 == 3).ToList().Count;
            ballNo2.Num4 = data.Where(i => i.No2 == 4).ToList().Count;
            ballNo2.Num5 = data.Where(i => i.No2 == 5).ToList().Count;
            ballNo2.Num6 = data.Where(i => i.No2 == 6).ToList().Count;
            ballNo2.Num7 = data.Where(i => i.No2 == 7).ToList().Count;
            ballNo2.Num8 = data.Where(i => i.No2 == 8).ToList().Count;
            ballNo2.Num9 = data.Where(i => i.No2 == 9).ToList().Count;
            result.No2Count = ballNo2;
            #endregion

            #region No3
            Array3Ball ballNo3 = new Array3Ball();
            ballNo3.Num0 = data.Where(i => i.No3 == 0).ToList().Count;
            ballNo3.Num1 = data.Where(i => i.No3 == 1).ToList().Count;
            ballNo3.Num2 = data.Where(i => i.No3 == 2).ToList().Count;
            ballNo3.Num3 = data.Where(i => i.No3 == 3).ToList().Count;
            ballNo3.Num4 = data.Where(i => i.No3 == 4).ToList().Count;
            ballNo3.Num5 = data.Where(i => i.No3 == 5).ToList().Count;
            ballNo3.Num6 = data.Where(i => i.No3 == 6).ToList().Count;
            ballNo3.Num7 = data.Where(i => i.No3 == 7).ToList().Count;
            ballNo3.Num8 = data.Where(i => i.No3 == 8).ToList().Count;
            ballNo3.Num9 = data.Where(i => i.No3 == 9).ToList().Count;
            result.No3Count = ballNo3;
            #endregion
            return result;
        }
        #endregion

        #region 获取每个数字下期出现的数字
        /// <summary>
        /// 获取每个数字下期出现的数字
        /// </summary>
        /// <param name="lotterResult"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<Arr3AnalysisEveryBallCount> GetArray3NextCountAsync(string lotterResult, List<Array3Analysis> data)
        {
            string[] arr = lotterResult.Split(",");
            int num1 = Convert.ToInt32(arr[0]);
            int num2 = Convert.ToInt32(arr[1]);
            int num3 = Convert.ToInt32(arr[2]);
            Arr3AnalysisEveryBallCount ballCountResult = new Arr3AnalysisEveryBallCount();
            var num1List = data.Where(i => i.No1 == num1).ToList();
            ballCountResult.No1Count = await GetNextNum(num1List, data);

            var num2List = data.Where(i => i.No2 == num2).ToList();
            ballCountResult.No2Count = await GetNextNum(num2List, data);

            var num3List = data.Where(i => i.No3 == num3).ToList();
            ballCountResult.No3Count = await GetNextNum(num3List, data);

            return ballCountResult;
        }
        private async Task<Array3Ball> GetNextNum(List<Array3Analysis> data, List<Array3Analysis> historyLotterData)
        {
            List<int> numData = new List<int>();
            foreach (var item in data)
            {
                //找下一期数据
                var nextTime = item.DrawDate.Value.AddDays(1);
                var nextData = historyLotterData.Where(i => i.DrawDate.Value == nextTime).FirstOrDefault();
                if (nextData != null)
                {
                    numData.Add(nextData.No1);
                    numData.Add(nextData.No2);
                    numData.Add(nextData.No3);
                }
            }
            Array3Ball ballNo = new Array3Ball();
            ballNo.Num0 = numData.Where(i => i == 0).ToList().Count;
            ballNo.Num1 = numData.Where(i => i == 1).ToList().Count;
            ballNo.Num2 = numData.Where(i => i == 2).ToList().Count;
            ballNo.Num3 = numData.Where(i => i == 3).ToList().Count;
            ballNo.Num4 = numData.Where(i => i == 4).ToList().Count;
            ballNo.Num5 = numData.Where(i => i == 5).ToList().Count;
            ballNo.Num6 = numData.Where(i => i == 6).ToList().Count;
            ballNo.Num7 = numData.Where(i => i == 7).ToList().Count;
            ballNo.Num8 = numData.Where(i => i == 8).ToList().Count;
            ballNo.Num9 = numData.Where(i => i == 9).ToList().Count;
            return ballNo;
        } 
        #endregion

        #endregion




        //=================================================================
        #region Job--爬虫获取排列三的数据
        public async Task SaveArray3InfoAsync()
        {

            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", "1.xlsx");
            string html = await File.ReadAllTextAsync(path);















            try
            {
                //await SaveArray3Analysis(null);
                //string array3Url = "https://www.lottery.gov.cn/kj/kjlb.html?pls";
                string array3Url = @"https://webapi.sporttery.cn/gateway/lottery/getHistoryPageListV1.qry?gameNo=35&provinceId=0&pageSize=20&isVerify=1&pageNo=1";
                string html = HttpRequestService.DownloadHtml(array3Url);
                await DataFilesService.SaveHtml(html, DateTime.Now.ToString("yyyy-MM-dd"), "Array3_1");
                LotteryArrayEntity lottery = JsonSerializer.Deserialize<LotteryArrayEntity>(html);
                await SaveArray3Data(lottery.Result.Data);

                #region MyRegion
                //string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", DateTime.Now.ToString("yyyy-MM-dd"), "Array3_47_20220413151502.txt");
                //string html = await File.ReadAllTextAsync(path);


                //LotteryArrayEntity lottery = JsonSerializer.Deserialize<LotteryArrayEntity>(html);
                //await SaveArray3Data(lottery.Result.Data);
                //for (int i = 1; i <= lottery.Result.Pages; i++)
                //{
                //    int pageIndex = i + 1;
                //    array3Url = $"https://webapi.sporttery.cn/gateway/lottery/getHistoryPageListV1.qry?gameNo=35&provinceId=0&pageSize=20&isVerify=1&pageNo={pageIndex}";
                //    html = HttpRequestService.DownloadHtml(array3Url);
                //    await DataFilesService.SaveHtml(html, DateTime.Now.ToString("yyyy-MM-dd"), $"Array3_{pageIndex}");
                //    LotteryArrayEntity item = JsonSerializer.Deserialize<LotteryArrayEntity>(html);
                //    await SaveArray3Data(item.Result.Data);
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        private async Task SaveArray3Data(List<Array3Entity> entities)
        {
            var array3List = await _db.DB.Queryable<Array3>().OrderBy(i=>i.ID).ToListAsync();
            List<Array3> arrayList = new List<Array3>();
            foreach (var item in entities)
            {
                var array3 = _mapper.Map<Array3>(item);
                array3.DrawResult = item.DrawResult.Replace(" ",",");
                array3.CreateTime = DateTime.Now;
                array3.ZhiAmount = item.Details[0].Amount;
                array3.ZhiLotterCount = item.Details[0].LotterCount;
                array3.ZhiName = item.Details[0].Name;
                array3.ZhiTotalPrizeAmount = item.Details[0].TotalPrizeAmount;

                array3.Group3Amount = item.Details[1].Amount;
                array3.Group3LotterCount = item.Details[1].LotterCount;
                array3.Group3Name = item.Details[1].Name;
                array3.Group3TotalPrizeAmount = item.Details[1].TotalPrizeAmount;

                array3.Group6Amount = item.Details[2].Amount;
                array3.Group6LotterCount = item.Details[2].LotterCount;
                array3.Group6Name = item.Details[2].Name;
                array3.Group6TotalPrizeAmount = item.Details[2].TotalPrizeAmount;

                array3.TotalSaleAmount = item.TotalSaleAmount;

                var isHas = array3List.Where(i => i.LotterNo == array3.LotterNo).FirstOrDefault();
                if(isHas==null)
                    arrayList.Add(array3);
            }
            if(await _db.DB.Insertable<Array3>(arrayList).ExecuteCommandAsync()>0)
                await SaveArray3Analysis(arrayList);
        }

        /// <summary>
        /// 把数据插入到分析数据中去
        /// </summary>
        /// <returns></returns>
        public async Task SaveArray3Analysis(List<Array3> entities)
        {
            
            //var arr3Data = await _db.DB.Queryable<Array3>().OrderBy(i => i.ID).ToListAsync();
            foreach (var item in entities)
            {
                Array3Analysis analysis = new Array3Analysis();
                analysis.LotterNo = item.LotterNo;
                if(!string.IsNullOrWhiteSpace(item.DrawDate))
                {
                    analysis.DrawDate = Convert.ToDateTime(item.DrawDate);
                }
                string[] arr = item.DrawResult.Split(",");
                analysis.No1 = Convert.ToInt32(arr[0]);
                analysis.No2 = Convert.ToInt32(arr[1]);
                analysis.No3 = Convert.ToInt32(arr[2]);
                await _db.DB.Insertable<Array3Analysis>(analysis).ExecuteCommandAsync();
            }
        }

        #endregion
    }
}
