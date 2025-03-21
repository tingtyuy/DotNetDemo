using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System_Diagnostics
{
    public class Process_
    {
        /// <summary>
        /// 文件被另一进程占用
        /// </summary>
        public static void KillProcess(string filename)
        {
            Process tool = new Process();
            tool.StartInfo.FileName = "handle.exe";//占用文件的进程
            tool.StartInfo.Arguments = filename + " /accepteula";
            tool.StartInfo.UseShellExecute = false;
            tool.StartInfo.RedirectStandardOutput = true;
            tool.Start();
            tool.WaitForExit();
            string outputTool = tool.StandardOutput.ReadToEnd();

            string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
            foreach (Match match in Regex.Matches(outputTool, matchPattern))
            {
                Process.GetProcessById(int.Parse(match.Value)).Kill();
            }
        }
    }
}
