﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.Microsoft.Extensions.DependencyInjection_
{
    public class ResponseCachingServicesExtensions_
    {
        public ResponseCachingServicesExtensions_()
        {
            var builder = WebApplication.CreateBuilder();
            //builder.Services.AddResponseCaching();

            var app=builder.Build();
            //app.UseResponseCaching();
            //app.Use(async (context, next) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl =
            //        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
            //        {
            //            Public = true,
            //            MaxAge = TimeSpan.FromSeconds(3 * 24 * 60 * 60)
            //        };
            //    await next();
            //});
            app.Run();
        }
    }
}
