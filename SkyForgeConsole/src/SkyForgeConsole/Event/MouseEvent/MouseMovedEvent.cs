/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Math;

namespace SkyForgeConsole.Events
{
    internal class MouseMovedEvent : Event
    {
        private Vector2 m_mousePos;
        public MouseMovedEvent(Vector2 positon) : base(EventType.MouseMoved, EventCategory.MouseEvent)
        {
            m_mousePos = positon;
        }

        public Vector2 GetMousePos()
        {
            return m_mousePos;
        }
    }
}
