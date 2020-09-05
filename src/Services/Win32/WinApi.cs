using System;
using System.Runtime.InteropServices;

namespace WallpaperChanger.Services.Win32
{
    public static class WinApi
    {
        [DllImport("user32.dll", SetLastError=true)]
        public static extern IntPtr FindWindow(string className, string windowName);

         [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,  string windowTitle);

        [DllImport("user32.dll", SetLastError=true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint message,IntPtr wParam,IntPtr lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, ref IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
