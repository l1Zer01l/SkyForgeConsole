/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public enum EventCategory
    {
        None = 1 << 0,
        ApplicationEvent = 1 << 1,
        InputEvent = 1 << 2,
        KeyEvent = 1 << 3,
        MouseEvent = 1 << 4
    }
}
