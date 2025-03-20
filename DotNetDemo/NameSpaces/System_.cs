using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces
{
    public class System_
    {

        /// <summary>
        /// Math
        /// 为三角、对数和其他常见数学函数提供常量和静态方法。
        /// 适用于需要高精度和double类型的场景。
        /// </summary>

        public void Math_()
        {
            // 返回两个数字中较小的一个
            Math.Min(1, 2);
            // 返回两个数字中较大的一个
            Math.Max(1, 2);

        }


        /// <summary>
        /// MathF
        /// 与Math基本相同，只是专门处理float类型的计算
        /// 为三角、对数和其他常见数学函数提供常量和静态方法。
        /// 适用于需要float类型和可能对性能有更高要求的场景
        /// </summary>

        public void MathF_()
        {
            //返回两个单精度浮点数中较小的一个
            MathF.Min(1f, 2f);
            //返回两个单精度浮点数中较大的一个
            MathF.Max(1f, 2f);
        }


    }
}
