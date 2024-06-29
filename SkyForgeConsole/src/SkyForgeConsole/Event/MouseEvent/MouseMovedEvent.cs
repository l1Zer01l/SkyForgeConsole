/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Math;

namespace SkyForgeConsole.Events
{
    internal class MouseMovedEvent : MouseEvent
    {
        private Vector2 m_mousePos;
        public MouseMovedEvent(Vector2 positon) : base(EventType.MouseMoved)
        {
            m_mousePos = positon;
        }

        public Vector2 GetMousePosition()
        {
            return m_mousePos;
        }
    }
}
