using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerCore.DependencyInjection
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public class DependencyInjectionCore
    {
        public static void Init()
        {
            var service = new ServiceCollection();
            service.BuildServiceProvider();
            service.AddSingleton<IMapper>();
        }
    }
}
