using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System.Text.Json_
{
    public static class JsonSerializerOptionsExtensions
    {
        /// <summary>
        /// 配置 序列化
        /// </summary>
        /// <param name="options"></param>
        public static JsonSerializerOptions ConfigJsonSerializerOptions(this JsonSerializerOptions options)
        {
            options.WriteIndented = true;
            options.AllowTrailingCommas = true;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new LseDateTimeConverter());
            return options;
        }


        /// <summary>
        /// 添加类型转换
        /// </summary>
        /// <param name="options">选项</param>
        /// <returns>JsonSerializerOptions</returns>
        public static JsonSerializerOptions AddTypeConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new ResModelDiscriminator());
            //options.Converters.Add(new FormDiscriminator());
            //options.Converters.Add(new ParamModelDiscriminator());
            return options;
        }
    }
}
