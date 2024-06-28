/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public class KeyRealesedEvent : KeyEvent
    {
        public KeyRealesedEvent(KeyCode typeKey) : base(EventType.KeyReleased, typeKey) { }
    }
}
