/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Core
{
    public abstract class Application : IApplication
    {
        public bool isRunning => m_isRunning;

        private bool m_isRunning;

        public void Init()
        {

            m_isRunning = true;
            OnInit();
        }
        public void Exit()
        {
            m_isRunning = false;
        }

        public void Run()
        {
            if (!m_isRunning)
                throw new MethodAccessException("don't called Init or Application disable");

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
