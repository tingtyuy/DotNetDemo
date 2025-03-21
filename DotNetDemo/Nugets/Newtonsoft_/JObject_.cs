using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.Nugets.Newtonsoft_
{
    internal class JObject_
    {
        /// <summary>
        /// object：适用于需要处理任意类型数据的通用场景。
        /// dynamic：适用于需要动态类型解析的场景，但需谨慎使用以避免运行时错误。
        /// JObject：适用于处理 JSON 数据，提供了丰富的操作功能。
        /// </summary>
        public static void Parse()
        {
            // 示例 JSON 字符串
            string jsonString = @"
            {
                ""name"": ""Bob"",
                ""age"": 25,
                ""skills"": [""C#"", ""JavaScript"", ""SQL""]
            }";

            // 解析JSON
            JObject json = JObject.Parse(jsonString);
        }
    }
}
