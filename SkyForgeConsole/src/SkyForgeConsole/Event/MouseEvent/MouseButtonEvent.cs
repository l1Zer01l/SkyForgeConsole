/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Math;

namespace SkyForgeConsole.Events
{
    public class MouseButtonEvent : MouseEvent
    {
        private MouseButtonType m_buttonType;
        private Vector2 m_positionPressed;
        public MouseButtonEvent(MouseButtonType buttonPressed, Vector2 positionPressed) : base(EventType.MousePressed,
                                                                                               EventCategory.InputEvent)
        {
            m_buttonType = buttonPressed;
            m_positionPressed = positionPressed;
        }

        public MouseButtonType GetButtonPressed()
        {
            return m_buttonType;
        }
        public bool IsMousePressed(MouseButtonType buttonPressed)
        {
            if (m_isHandled)
                return false;

            m_isHandled = buttonPressed.Equals(m_buttonType);

            return m_isHandled;
        }

        public Vector2 GetMousePosition()
        {
            return m_positionPressed;
        }
    }
}
