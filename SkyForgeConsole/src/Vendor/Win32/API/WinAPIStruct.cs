/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Runtime.InteropServices;

namespace SkyForgeConsole.Vendor.Win32.API
{
    internal static partial class WinAPINative
    {
        internal static Int32 VK_LBUTTON = 0x01;
        internal static Int32 VK_RBUTTON = 0x02;
        internal static Int32 VK_MBUTTON = 0x04;
        internal static Int32 VK_TBUTTON = 0x05;
        internal static Int32 VK_FBUTTON = 0x06;

        [StructLayout(LayoutKind.Sequential)]
        internal class POINT
        {
            internal int x;
            internal int y;

            internal POINT() : this(0, 0) { }
            internal POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        }
    }
}
