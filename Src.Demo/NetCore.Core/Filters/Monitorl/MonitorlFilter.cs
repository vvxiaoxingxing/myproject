using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NetCore.Infrastructure.Extension;
using NetCore.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Core.Filters.Monitorl
{
    public class MonitorlFilter : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        private readonly ILogger _logger;
        public int Order => 6665;
        public MonitorlFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MonitorlFilter>();
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var monitor = RequestMonitor.Start(_logger))
            {
                var executedContext = await next.Invoke();
                monitor.Push(new
                {
                    Exception = executedContext?.Exception?.ToString(),
                    LevelType = (executedContext?.Exception != null ? -999 : 0),
                    LogType = 2,
                    Message = await context.HttpContext.Request.GetParameters(),
                    CreateUserID = 1,//(int)this._cmsRequest.UserId,
                    CreateDateTime = DateTime.Now
                });
            }
        }
    }
}
