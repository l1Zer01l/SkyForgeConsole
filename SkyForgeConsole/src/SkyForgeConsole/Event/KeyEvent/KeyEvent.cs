/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;

namespace SkyForgeConsole.Events
{
    public class KeyEvent : Event, IKeyEvent
    {
        protected KeyCode m_keyCode;
        public KeyEvent(EventType eventType, KeyCode keyCode) : base(eventType, 
                                                                     EventCategory.InputEvent | 
                                                                     EventCategory.KeyEvent)
        {
            m_keyCode = keyCode;
        }

        public KeyCode GetKeyCode()
        {
            return m_keyCode;
        }

        protected bool IsKey(KeyCode keyCode)
        {
            if (m_isHandled)
                return false;

            m_isHandled = m_keyCode.Equals(keyCode);
            return m_isHandled;
        }
    }
}
