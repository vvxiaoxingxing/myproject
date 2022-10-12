using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Core.Filters.Authorize
{
    /// <summary>
    /// 处理授权全局过滤器
    /// </summary>
    public class AuthorizeCoreFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            return Task.CompletedTask;
        }
    }
}
