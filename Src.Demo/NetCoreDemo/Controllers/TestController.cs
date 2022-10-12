using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetCoreDemo.Controllers
{
    [ApiController]
    public class TestController : BaseApiController
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Test/Get")]
        public async Task<bool> GetList()
        {
            var a = 10;
            var b = 20;
            var c = (a+b)/0;
            return false;
        }
    }
}
