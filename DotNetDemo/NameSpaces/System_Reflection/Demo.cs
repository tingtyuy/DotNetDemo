using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System_Reflection
{
    public class Demo
    {
        /// <summary>
        /// 通过特性名得到字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static string GetField<T>(string displayName)
        {

            var type = typeof(T);
            var property = type.GetProperties().FirstOrDefault(w => w.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName == displayName);
            return property?.Name;
        }


        /// <summary>
        /// 通过特性名得到字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static string GetField<T>(string displayName, T instance)
        {

            var type = instance.GetType();
            var property = type.GetProperties().FirstOrDefault(w => w.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName == displayName);
            return property?.Name;
        }

        /// <summary>
        /// 判断可空属性是不是枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsEnumType(PropertyInfo property)
        {

            if (property.PropertyType.IsGenericType && property.PropertyType.GenericTypeArguments[0].BaseType.Name == "Enum")
            {

                return true;

            }
            else if (property.PropertyType.IsEnum)
            {
                return true;

            }
            return false;

        }

        /// <summary>
        /// 返回可空属性的数据类型
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Type GetPropertyType(PropertyInfo property)
        {

            if (property.PropertyType.IsGenericType)
            {

                return property.PropertyType.GenericTypeArguments[0];

            }
            else
            {
                return property.PropertyType;
            }

        }

        /// <summary>
        /// 返回可空属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <param name="stringValue">没有数据类型的字符串表现形式的值</param>
        /// <returns></returns>
        public static object GetPropertyValue(PropertyInfo property, string stringValue)
        {
            var isEnum = IsEnumType(property);
            var type = GetPropertyType(property);
            if (isEnum)
            {
                return Enum.Parse(type, stringValue);
            }
            else
            {

                if (type.Name == "Boolean")
                {
                    if (stringValue == "1")
                    {
                        stringValue = "true";
                    }
                    else if (stringValue == "0")
                    {
                        stringValue = "false";
                    }
                }
                return Convert.ChangeType(stringValue, type);
            }

        }
        /// <summary>
        /// 获得对象的所有属性和值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetProperties<T>(T t, StringBuilder strb = null)
        {
            if (strb == null)
            {
                strb = new StringBuilder();
            }


            if (t == null)
            {
                return strb.ToString();
            }
          
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return strb.ToString();
            }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    strb.AppendLine(string.Format("{0}:{1},", name, value));
                }
                else
                {
                    GetProperties(value, strb);
                }
            }
            return strb.ToString();
        }
    }
}
