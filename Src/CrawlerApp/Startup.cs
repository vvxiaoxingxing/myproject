using AutoMapper;
using CrawlerCore.Options;
using CrawlerService;
using CrawlerService.AutoMapperService;
using DbContextAccess;
using ICrawlerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(p =>
            {
                p.JsonSerializerOptions.PropertyNamingPolicy = null;//去掉默认为小写
            });

            services.AddOptions();
            //
            services.Configure<DBOptions>(Configuration.GetSection("DBConfig"));

            services.AddAutoMapper(typeof(AutoMapperConfigs));

            //注册服务
            services.AddTransient<IArray3Service, Array3Service>();
            services.AddTransient<DataFilesService>();
            services.AddSingleton<SqlSugarFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
