using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetDemo.NameSpaces.System_Xml_Serialization
{
    public class System_Xml_Serialization
    {
        public static void XmlSerializer_()
        {



        }
        public static List<T> ToList<T>(string xml, string rootName) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
            using (StringReader sr = new StringReader(xml))
            {
                List<T> list = serializer.Deserialize(sr) as List<T>;
                return list;
            }
        }
    }
}
