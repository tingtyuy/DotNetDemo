using FastExpressionCompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vanara.PInvoke.Kernel32;

namespace DotNetDemo.Nugets.System.Linq.Dynamic.Core_
{
    public class Demo
    {
        public Demo() { }

        public static void Invoke()
        {
            //Strongly typed LINQ looks like:

            //var result = context.Customers
            //    .Where(c => c.City == "Paris")
            //    .ToList();

            //Dynamic LINQ looks like:

            //var resultDynamic = context.Customers
            //    .Where("City == \"Paris\"")
            //    .ToList();
        }
    }
}
