using System;
using System.Runtime.InteropServices;

namespace AntiVirusTask
{
    internal static class NativeMethods
    {
        [DllImport("User32.dll", EntryPoint = "MessageBox",
            CharSet = CharSet.Auto)]
        internal static extern int MsgBox(
            IntPtr hWnd, string lpText, string lpCaption, uint uType);

        [DllImportAttribute("User32.dll")]
        internal static extern int FindWindow(String ClassName, String WindowName);

        [DllImportAttribute("User32.dll")]
        internal static extern IntPtr SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        public static int SendQuitMessage(int hWnd)
        {
            return SendMessage(hWnd, 0x0010, 0, 0);
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
}
