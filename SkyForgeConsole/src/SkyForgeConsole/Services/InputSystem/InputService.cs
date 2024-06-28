/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;
using SkyForgeConsole.Math;
using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Services.Input
{
    public class InputService : IInputService
    {
        private const int DELTA_PRESSED = 40;

        public event Action<Event>? eventCalled;

        private ConsoleKeyInfo m_lastKeyPressed;
        private static InputService? m_instance;
        private static BaseInput? m_baseInput;

        private bool m_isRunning;
        private bool m_IsRealesed;
        private int m_deltaTime;

        private int m_timeToWaitLastPressed;

        private InputService()
        {
            Console.CursorVisible = false;
            
            m_IsRealesed = true;
            m_isRunning = true;
        }

        internal static IInputService GetInputService<T>() where T : BaseInput
        {
            if (m_instance is null)
            {
                m_baseInput = BaseInput.GetInputSystem<T>();
                m_instance = new InputService();
            }

            return m_instance;
        }

        public void Init()
        {
            Thread threadInput = new Thread(new ThreadStart(Run));
            m_baseInput.OnMouseMovedEvnent += OnMouseMoved;
            m_baseInput.OnMouseButtonPressed += OnMouseButton;
            Log.CoreLogger?.Logging("Initialized Input System", LogLevel.Info);
            threadInput.Start();
        }

        public void Destroy()
        {
            m_isRunning = false;
        }

        public static Vector2 GetCursorPos()
        {
            return m_baseInput?.GetCursorPosition() ?? new Vector2();
        }

        private void OnPressedKey(ConsoleKeyInfo keyInfo)
        {
            var keyType = (KeyCode)keyInfo.Key;
            var keyPressedEvent = new KeyPressedEvent(keyType);
            eventCalled?.Invoke(keyPressedEvent);
        }

        private void OnRealeseKey(ConsoleKeyInfo keyInfo)
        {
            var keyType = (KeyCode)keyInfo.Key;
            var keyRealeseEvent = new KeyRealesedEvent(keyType);
            eventCalled?.Invoke(keyRealeseEvent);
        }

        private void OnMouseMoved(Vector2 cursorPosition)
        {
            var mouseScrollEvent = new MouseMovedEvent(cursorPosition);
            eventCalled?.Invoke(mouseScrollEvent);
        }

        private void OnMouseButton(MouseButtonType button)
        {
            var mouseButtonEvent = new MouseButtonEvent(button, GetCursorPos());
            eventCalled?.Invoke(mouseButtonEvent);
        }

        private void Run()
        {
            Thread threadInput = new Thread(new ThreadStart(RunTime));
            threadInput.Start();

            while (m_isRunning)
            {

                m_lastKeyPressed = Console.ReadKey(true);
                m_IsRealesed = false;
                m_timeToWaitLastPressed = 0;
                OnPressedKey(m_lastKeyPressed);
            }
        }

        private void RunTime()
        {
            while (m_isRunning)
            {
                var startTime = DateTime.Now.Millisecond;

                RealesedKey();
                m_baseInput?.UpdateSystem();

                Thread.Sleep(1);

                m_deltaTime = DateTime.Now.Millisecond - startTime;
            }
        }

        private void RealesedKey()
        {
            m_timeToWaitLastPressed += m_deltaTime;

            if (m_timeToWaitLastPressed > DELTA_PRESSED && !m_IsRealesed)
            {
                OnRealeseKey(m_lastKeyPressed);
                m_IsRealesed = true;
                m_timeToWaitLastPressed = 0;
            }
        }
    }
}
