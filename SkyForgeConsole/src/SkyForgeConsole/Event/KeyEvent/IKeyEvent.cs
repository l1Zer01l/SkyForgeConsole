/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public interface IKeyEvent
    {
        KeyCode GetKeyCode();
    }
}
