using CrawlerApp.Models;
using CrawlerCore.Options;
using ICrawlerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<DBOptions> _option;
        private readonly IArray3Service _array3Service;
        public HomeController(ILogger<HomeController> logger,
            IOptions<DBOptions> option,
            IArray3Service array3Service)
        {
            _logger = logger;
            _option = option;
            _array3Service = array3Service;
        }

        public IActionResult Index()
        {
            _array3Service.SaveArray3InfoAsync();
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 获取排列3前20期数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetArray3Info(int PageSize = 20)
        {
            var data = await _array3Service.GetArray3InfoAsync(PageSize);
            return Json(new
            {
                Data = data,
                Success = true,
                Msg = "success"
            }) ;
        }

        /// <summary>
        /// 根据期号获取分析数据
        /// </summary>
        /// <param name="lotterNo"></param>
        /// <param name="lotterNoCount"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetArray3AnalysisInfo(string lotterNo,int lotterNoCount)
        {
            var data = await _array3Service.GetArray3AnalysisAsync(lotterNo, lotterNoCount);
            return Json(new
            {
                Data = data,
                Success = true,
                Msg = "success"
            });
        }
    }
}
