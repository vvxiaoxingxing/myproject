using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Core.Filters.Exception
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _logger;
        public ExceptionFilter(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<ExceptionFilter>();
        }
        /// <summary>
        /// 异常处理器
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception.ToString());
            await Task.CompletedTask;
        }

        
    }
}
