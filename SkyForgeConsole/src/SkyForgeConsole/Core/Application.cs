/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Core
{
    public abstract class Application : IApplication
    {
        public bool IsRunning => m_isRunning;

        private bool m_isRunning;

        public void Init()
        {

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
        private void Destroy()
        {

            OnDestroy();
        }
    }
}
