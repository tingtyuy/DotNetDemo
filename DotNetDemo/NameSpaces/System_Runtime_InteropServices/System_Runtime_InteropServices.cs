using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System_Runtime_InteropServices
{
    public class System_Runtime_InteropServices
    {

    }

    /// <summary>
    /// 控制台帮助类
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// 获取窗口句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern nint FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 设置窗体的显示与隐藏
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(nint hWnd, uint nCmdShow);

        /// <summary>
        /// 隐藏控制台
        /// </summary>
        /// <param name="ConsoleTitle">控制台标题(可为空,为空则取默认值)</param>
        public static void hideConsole(string ConsoleTitle = "")
        {
            ConsoleTitle = string.IsNullOrEmpty(ConsoleTitle) ? Console.Title : ConsoleTitle;
            nint hWnd = FindWindow("ConsoleWindowClass", ConsoleTitle);
            if (hWnd != nint.Zero)
            {
                ShowWindow(hWnd, 0);
            }
        }

        /// <summary>
        /// 显示控制台
        /// </summary>
        /// <param name="ConsoleTitle">控制台标题(可为空,为空则去默认值)</param>
        public static void showConsole(string ConsoleTitle = "")
        {
            ConsoleTitle = string.IsNullOrEmpty(ConsoleTitle) ? Console.Title : ConsoleTitle;
            nint hWnd = FindWindow("ConsoleWindowClass", ConsoleTitle);
            if (hWnd != nint.Zero)
            {
                ShowWindow(hWnd, 1);
            }
        }
    }
}
