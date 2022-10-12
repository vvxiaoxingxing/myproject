using Core.Jwt.Demo.Options;
using Core.Jwt.Demo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Jwt.Demo.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<TokenServices>();

            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Position));
            services.AddJwt();
           
            return services;
        }

        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                var options = services.BuildServiceProvider().GetService<IOptions<JwtOptions>>();
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Value.Issuer,
                    ValidAudience = options.Value.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.SecretKey)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateActor = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(1)
                };
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = (context) =>
                    {
                        if (!context.HttpContext.Request.Path.HasValue)
                        {
                            return Task.CompletedTask;
                        }
                        //判断是Signalr的路径
                        var accessToken = context.HttpContext.Request.Headers["Authorization"];
                        if (string.IsNullOrWhiteSpace(accessToken))
                        {
                            accessToken = context.HttpContext.Request.Query["access_token"];
                            if (string.IsNullOrWhiteSpace(accessToken))
                            {
                                return Task.CompletedTask;
                            }
                        }
                        else
                        {
                            var arr = accessToken.ToString().Split(" ");
                            if (arr.Length != 2)
                            {
                                return Task.CompletedTask;
                            }
                            accessToken = arr[1];
                        }
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            context.Token = accessToken;
                            return Task.CompletedTask;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }

        /// <summary>
        /// Swagger UI
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddSwaggerGenDoc(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Open Api", Version = "v1" });
                var dir = new DirectoryInfo(AppContext.BaseDirectory);

                foreach (FileInfo file in dir.EnumerateFiles("*.xml"))
                {
                    c.IncludeXmlComments(file.FullName);
                }

                c.AddSecurityDefinition("Bearer",
                   new OpenApiSecurityScheme
                   {
                       Description = "请输入OAuth接口返回的Token，前置Bearer。示例：Bearer {Roken}",
                       Name = "Authorization",
                       In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                       Type = SecuritySchemeType.ApiKey
                   });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, Array.Empty<string>()
                    }
                });
                //c.DocumentFilter<EnumDocumentFilter>();

            });
            return mvcBuilder;
        }
    }
}
