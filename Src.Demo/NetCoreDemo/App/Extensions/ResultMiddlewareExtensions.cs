using Microsoft.AspNetCore.Builder;
using NetCoreDemo.App.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.App.Extensions
{
    public static class ResultMiddlewareExtensions
    {
        public static IApplicationBuilder UseResult(
           this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResultMiddleware>();
        }
    }
}
