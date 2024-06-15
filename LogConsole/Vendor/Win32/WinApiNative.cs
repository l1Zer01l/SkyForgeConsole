/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Runtime.InteropServices;

namespace LogConsole.Vendor.Win32
{
    internal static class WinApiNative
    {
        internal const Int32 BUTTON_CLOSE = 0xF060;

        internal const Int32 LB_COMMAND = 0x00000000;
        internal const Int32 LB_ENABLE = 0x00000000;
        internal const Int32 LB_DISABLE = 0x00000001;

        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        private static IntPtr GetHandleMenu()
        {
            return GetSystemMenu(GetConsoleWindow(), false);
        }

        internal static void EnableButtonMenu(uint Button, uint UEnable)
        {
            EnableMenuItem(GetHandleMenu(), Button, UEnable);
        }
    }
}
