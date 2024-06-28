/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SkyForgeConsole.Vendor.Win32.API
{
    internal static partial class WinAPINative
    {
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern bool GetCursorPos([In, Out] POINT pt);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int nVirtKey);

        internal static bool GetConsoleRect(IntPtr handle, out RECT lpRect)
        {
            var hWnd = new HandleRef(null, handle);
            return GetWindowRect(hWnd, out lpRect);
        }

        internal static POINT GetConsoleCursorPos()
        {
            var handle = GetConsoleWindow();
            var pointCursor = new POINT();
            GetCursorPos(pointCursor);
            var rect = new RECT();
            GetConsoleRect(handle, out rect);
            pointCursor.x -= rect.left;
            pointCursor.y -= rect.top;
            return pointCursor;
        }

        internal static bool IsButtonPressed(Int32 VK)
        {
            return ((byte)GetKeyState(VK) & 1 << 7) != 0;
        }
    }
}
