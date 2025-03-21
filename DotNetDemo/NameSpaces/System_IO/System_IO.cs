using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

       



        #endregion
    }
}
