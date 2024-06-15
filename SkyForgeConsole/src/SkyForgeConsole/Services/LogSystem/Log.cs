/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Services.LogSystem
{
    public static class Log
    {
        public static ILogger? CoreLogger => m_coreLogger;
        public static ILogger? ClienLogger => m_clientLogger;

        private static Logger? m_coreLogger;
        private static Logger? m_clientLogger;
        public static void Init()
        {
            ConsoleLogger.Init();
            m_coreLogger = new Logger("SkyForgeEngine");
            m_clientLogger = new Logger("Client");

            m_coreLogger.Init(true, true);
            m_clientLogger.Init(true);

            m_coreLogger.Logging("Initialized Log System", LogLevel.Info);
        }
        public static void Destroy()
        {
            m_coreLogger?.Destroy();
            m_clientLogger?.Destroy();

            ConsoleLogger.Destroy();
        }
    }
}
