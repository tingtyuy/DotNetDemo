using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.Microsoft_Extensions_Configuration
{
    /// <summary>
    /// 包含用于设置 IConfiguration 的类和抽象。
    /// https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.extensions.configuration?view=net-9.0-pp&devlangs=csharp&f1url=%3FappId%3DDev17IDEF1%26l%3DZH-CN%26k%3Dk(Microsoft.Extensions.Configuration)%3Bk(DevLang-csharp)%26rd%3Dtrue
    /// </summary>
    public class Microsoft_Extensions_Configuration
    {
        /// <summary>
        /// 构建应用程序配置的核心类。它允许开发者从多种配置源（如 JSON 文件、环境变量、命令行参数、用户机密等）加载配置，并将它们合并成一个统一的配置对象
        /// </summary>
        public void ConfigurationBuilder_()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("dbSetting.json", optional: false, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            builder.Build();
        }
        //public string GetExcleConfigDirectory()
        //{
        //    SqlSugarHelper.GetSetting().DbType
        //}
        //public static ConnectionStringsOptions GetSetting()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("dbSetting.json", optional: false, reloadOnChange: true);

        //    IConfigurationRoot config = builder.Build();
        //    return config.GetSection("ConnectionConfigs").Get<ConnectionStringsOptions>()!;
        //}


    }
}
