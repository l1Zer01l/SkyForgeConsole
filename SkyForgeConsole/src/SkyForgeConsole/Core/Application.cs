/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;
using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Core
{
    public abstract class Application : IApplication
    {
        public bool IsRunning => m_isRunning;

        private IInputService? m_inputService;
        private bool m_isRunning;

        public void Init()
        {
            //Init Input System
            m_inputService = InputService.GetInputService();
            m_inputService.eventCalled += OnEvent;
            m_inputService.Init();

            m_isRunning = true;
            Log.CoreLogger?.Logging("Welcome to SkyForgeConsole", LogLevel.Info);
            OnInit();
        }
        public void Exit()
        {
            m_isRunning = false;
        }

        public void Run()
        {
            if (!m_isRunning)
            {
                Log.CoreLogger?.Logging("Don't called Init or Application disable", LogLevel.Error);
                throw new MethodAccessException("don't called Init or Application disable");
            }

            while (m_isRunning)
            {
                
            }

            Destroy();
        }

        protected virtual void OnInit() { }
        protected virtual void OnDestroy() { }

        private void OnEvent(Event e)
        {
            if (e.IsEventCategory(EventCategory.InputEvent))
            {
                if (e is KeyPressedEvent pressedEvent)
                {
                    if (pressedEvent.GetKeyCode().Equals(KeyCode.Escape))
                        Exit();

                    if (pressedEvent.IsPressedKey(KeyCode.W))
                        Console.WriteLine("Yeeeeeees");

                    if (pressedEvent.IsPressedKey(KeyCode.W))
                        Console.WriteLine("Noooo");
                }

                
            }
            
        }

        private void Destroy()
        {
            m_inputService?.Destroy();

            OnDestroy();
        }
    }
}
