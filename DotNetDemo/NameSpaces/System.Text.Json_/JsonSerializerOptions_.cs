using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System.Text.Json_
{
    public class JsonSerializerOptions_
    {
        public static JsonSerializerOptions OptionsWithTypes
        {
            get { return new JsonSerializerOptions().ConfigJsonSerializerOptions().AddTypeConverters(); }
        }

        public static JsonSerializerOptions Options
        {
            get { return new JsonSerializerOptions().ConfigJsonSerializerOptions(); }
        }
    }
}
