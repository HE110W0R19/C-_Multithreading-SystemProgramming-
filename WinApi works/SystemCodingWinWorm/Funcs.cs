using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemCodingWinWorm
{
    internal static class NativeMethods
    {
        public const uint WM_SETTEXT = 0x000C;

        [DllImport("User32.dll", EntryPoint = "MessageBox",
            CharSet = CharSet.Auto)]
        internal static extern int MsgBox(
            IntPtr hWnd, string lpText, string lpCaption, uint uType);

        [DllImportAttribute("User32.dll")]
        internal static extern int FindWindow(String ClassName, String WindowName);

        [DllImportAttribute("User32.dll")]
        internal static extern IntPtr SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, string lParam);
        public static int SendQuitMessage(int hWnd)
        {
            return SendMessage(hWnd, 0x0010, 0, null);
        }
    }
}
