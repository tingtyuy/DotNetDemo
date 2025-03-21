using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.Nugets.Newtonsoft_
{

    /// <summary>
    /// 实现 根据路径解析json值
    /// </summary>
    /// <remarks> 参考：https://github.com/dotnet/runtime/issues/38324  由于目前system.text.json不支持，暂时使用Newtonsoft.Json</remarks>
    public class JsonPathConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var targetObj = Activator.CreateInstance(objectType);

            foreach (var prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                var att = prop.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();

                var jsonPath = att != null ? att.PropertyName : prop.Name;

                if (serializer.ContractResolver is DefaultContractResolver)
                {
                    var resolver = (DefaultContractResolver)serializer.ContractResolver;
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);
                }

                // if (!Regex.IsMatch(jsonPath, @"^[a-zA-Z0-9_.-]+$"))
                // {
                //     throw new InvalidOperationException($"JProperties of JsonPathConverter can have only letters, numbers, underscores, hiffens and dots but name was ${jsonPath}."); // Array operations not permitted
                // }

                var token = jo.SelectToken(jsonPath);
                if (token != null && token.Type != JTokenType.Null)
                {
                    var value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }

        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return objectType.GetCustomAttributes(true).OfType<JsonPathConverter>().Any();
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
