using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NetCoreDemo.App.Filters
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _logger;
        public ExceptionFilter(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<ExceptionFilter>();
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
