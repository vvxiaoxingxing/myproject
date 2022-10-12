using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Core.Filters.Authorize;
using NetCore.Core.Filters.Exception;
using NetCore.Core.Filters.Monitorl;
using NetCore.Core.Lib.JWT;
using NetCore.Core.Lib.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwagger();
            return services;
        }

        /// <summary>
        /// 注册Jwt
        /// </summary>
        public static IServiceCollection AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtCore(configuration);
            return services;
        }

        /// <summary>
        /// 注册 过滤器
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IMvcBuilder AddFilters(this IMvcBuilder app)
        {
            app.AddMvcOptions(option => {
                option.Filters.Add<AuthorizeCoreFilter>();
                option.Filters.Add<ExceptionFilter>();
                option.Filters.Add<MonitorlFilter>();
            });
            return app;
        }
    }
}
