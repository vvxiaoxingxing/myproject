using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructure.DependencyInjection
{
    public static class FiltersServiceExtensions
    {
        /// <summary>
        /// 注册 过滤器
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IMvcBuilder AddFilters(this IMvcBuilder app)
        {
            //app.AddMvcOptions(option => {
            //    option.Filters.Add<ExceptionFilter>();
            //    option.Filters.Add<MonitorlFilter>();
            //});
            return app;
        }
    }
}
