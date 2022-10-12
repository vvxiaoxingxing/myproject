﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.App.Middlewares
{
    public class ResultMiddleware
    {
        private readonly RequestDelegate _next;

        public ResultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            Console.WriteLine($"1");
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
