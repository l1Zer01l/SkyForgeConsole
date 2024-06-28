/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Math;

namespace SkyForgeConsole.Events
{
    internal class MouseButtonEvent : Event
    {
        private MouseButtonType m_buttonType;
        private Vector2 m_positionPressed;
        public MouseButtonEvent(MouseButtonType buttonPressed, Vector2 positionPressed) : base(EventType.MousePressed,
                                                                                               EventCategory.InputEvent |
                                                                                               EventCategory.MouseEvent)
        {
            m_buttonType = buttonPressed;
            m_positionPressed = positionPressed;
        }

        public MouseButtonType GetButtonPressed()
        {
            return m_buttonType;
        }

        public Vector2 GetMousePos()
        {
            return m_positionPressed;
        }
    }
}
