/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Core
{
    public class EntryPoint : IEntryPoint
    {
        private static EntryPoint? m_instance;

        private IApplication? m_application;
        private EntryPoint()
        {
            
        }

        public static IEntryPoint GetEntryPoint()
        {
            if (m_instance is null)
                m_instance = new EntryPoint();

            return m_instance;
        }

        public void Destroy()
        {
            
        }

        public IApplication? GetApplication()
        {
            return m_application;
        }

        public void Init(IApplication application)
        {
            m_application = application;
            m_application.Init();
        }
    }
}
