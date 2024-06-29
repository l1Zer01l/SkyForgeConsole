﻿/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public class KeyRealesedEvent : KeyEvent
    {
        public KeyRealesedEvent(KeyCode keyCode) : base(EventType.KeyReleased, keyCode) { }

        public bool IsKeyRealesed(KeyCode keyCode)
        {
            return IsKey(keyCode);
        }
    }
}
