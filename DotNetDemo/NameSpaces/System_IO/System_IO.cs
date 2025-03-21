using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System_IO
{
    public class System_IO
    {
        #region Stream
        public static void Stream_()
        {

        }
        public static Stream CopyToMemory(Stream input, Stream output)
        {
            // It won't matter if we throw an exception during this method;
            // we don't *really* need to dispose of the MemoryStream, and the
            // caller should dispose of the input stream


            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
            // Rewind ready for reading (typical scenario)
            output.Position = 0;
            return output;
        }
        #endregion

        #region File
        public static void File_()
        {


        }

        /// <summary>
        /// 文件被占用强制删除
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="timesToWrite"></param>
        public static void WipeFile(string filename, int timesToWrite)
        {
            try
            {
                if (File.Exists(filename))
                {
                    //设置文件的属性为正常，这是为了防止文件是只读
                    File.SetAttributes(filename, FileAttributes.Normal);
                    //计算扇区数目
                    double sectors = Math.Ceiling(new FileInfo(filename).Length / 512.0);
                    // 创建一个同样大小的虚拟缓存
                    byte[] dummyBuffer = new byte[512];
                    // 创建一个加密随机数目生成器
                    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                    // 打开这个文件的FileStream
                    FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
                    {
                        // 文件流位置
                        inputStream.Position = 0;
                        //循环所有的扇区
                        for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
                        {
                            //把垃圾数据填充到流中
                            rng.GetBytes(dummyBuffer);
                            // 写入文件流中
                            inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
                        }
                    }
                    // 清空文件
                    inputStream.SetLength(0);
                    // 关闭文件流
                    inputStream.Close();
                    // 清空原始日期需要
                    DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                    File.SetCreationTime(filename, dt);
                    File.SetLastAccessTime(filename, dt);
                    File.SetLastWriteTime(filename, dt);
                    // 删除文件
                    File.Delete(filename);
                }
            }
            catch (Exception)
            {
            }
        }



        #endregion
    }
}
