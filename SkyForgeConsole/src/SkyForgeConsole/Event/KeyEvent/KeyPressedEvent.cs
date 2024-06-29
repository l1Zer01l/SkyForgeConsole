/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public class KeyPressedEvent : KeyEvent
    {
        public KeyPressedEvent(KeyCode keyCode) : base(EventType.KeyReleased, keyCode) { }

        public bool IsPressedKey(KeyCode keyCode)
        {
            return IsKey(keyCode);
        }
    }
}
