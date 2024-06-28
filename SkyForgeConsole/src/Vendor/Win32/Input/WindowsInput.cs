/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Vendor.Win32.API;
using SkyForgeConsole.Math;
using SkyForgeConsole.Events;

namespace SkyForgeConsole.src.Vendor.Win32.Input
{
    internal sealed class WindowsInput : BaseInput
    {
        internal override event Action<Vector2>? OnMouseMovedEvnent;
        internal override event Action<MouseButtonType>? OnMouseButtonPressed;

        private Vector2 m_lastMousePosition;
        internal override Vector2 GetCursorPosition()
        {
            var pointCursor = WinAPINative.GetConsoleCursorPos();

            var vectorCursor = new Vector2(pointCursor.x, pointCursor.y);
            return vectorCursor;
        }

        internal override void UpdateSystem()
        {
            MouseMoved();
            MouseButton();
        }

        private void MouseMoved()
        {
            var cursorPosition = GetCursorPosition();
            if (m_lastMousePosition != cursorPosition)
                OnMouseMovedEvnent?.Invoke(cursorPosition);
            m_lastMousePosition = cursorPosition;
        }

        private void MouseButton()
        {
            if (WinAPINative.IsButtonPressed(WinAPINative.VK_LBUTTON))
                OnMouseButtonPressed?.Invoke(MouseButtonType.LeftButton);

            if (WinAPINative.IsButtonPressed(WinAPINative.VK_MBUTTON))
                OnMouseButtonPressed?.Invoke(MouseButtonType.MiddleButton);

            if (WinAPINative.IsButtonPressed(WinAPINative.VK_RBUTTON))
                OnMouseButtonPressed?.Invoke(MouseButtonType.RightButton);

            if (WinAPINative.IsButtonPressed(WinAPINative.VK_TBUTTON))
                OnMouseButtonPressed?.Invoke(MouseButtonType.Thirdbutton);

            if (WinAPINative.IsButtonPressed(WinAPINative.VK_FBUTTON))
                OnMouseButtonPressed?.Invoke(MouseButtonType.Fourthbutton);

        }
    }
}
