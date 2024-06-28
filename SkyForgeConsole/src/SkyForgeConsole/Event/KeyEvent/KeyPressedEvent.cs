/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public class KeyPressedEvent : KeyEvent
    {
        public KeyPressedEvent(KeyCode typeKey) : base(EventType.KeyReleased, typeKey) { }

    }
}
