/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.LogSystem;
using SkyForgeConsole.src.Vendor.Win32.Input;
using SkyForgeConsole.Math;
using SkyForgeConsole.Events;

namespace SkyForgeConsole.Services.Input
{
    internal abstract class BaseInput
    {
        internal abstract event Action<Vector2>? OnMouseMovedEvnent;
        internal abstract event Action<MouseButtonType>? OnMouseButtonPressed;
        internal abstract Vector2 GetCursorPosition();
        internal abstract void UpdateSystem();

        public static BaseInput GetInputSystem<T>() where T : BaseInput
        {
            var type = typeof(T);
            if (type.Equals(typeof(WindowsInput)))
                return new WindowsInput();

            Log.CoreLogger?.Logging($"unknown class type: {type} inherited from BaseInput", LogLevel.Error);
            throw new ArgumentException($"unknown class type: {type} inherited from BaseInput");
        }
    }
}
