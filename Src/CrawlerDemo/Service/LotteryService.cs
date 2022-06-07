using CrawlerDemo.Infrastructure;
using CrawlerDemo.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrawlerDemo.Service
{
    /// <summary>
    /// 彩票数据采集器
    /// </summary>
    public static class LotteryService
    {
        /// <summary>
        /// 获取排列3的过往数据
        /// </summary>
        public static void GetArray3()
        {
            //string array3Url = "https://www.lottery.gov.cn/kj/kjlb.html?pls";
            string array3Url = @"https://webapi.sporttery.cn/gateway/lottery/getHistoryPageListV1.qry?gameNo=35&provinceId=0&pageSize=30&isVerify=1&pageNo=1";
            string html = RequestService.DownloadHtml(array3Url);

            


            //LotteryArray lottery = JsonSerializer.Deserialize<LotteryArray>(html);

            //HtmlDocument document = new HtmlDocument();
            //document.LoadHtml(html);
            //{
            //    string secondPath = "//*[@id=\"historyData\"]";
            //    HtmlNodeCollection nodeList = document.DocumentNode.SelectNodes(secondPath);//找多个节点
            //    if (nodeList != null)
            //    {
            //        foreach (HtmlNode node in nodeList)
            //        {
            //            string url = node.Attributes["href"].Value;
            //            string name = node.InnerText;
            //            //logger.Info($"{name}:{url}");
            //        }
            //    }
            //}

        }
    }
}
