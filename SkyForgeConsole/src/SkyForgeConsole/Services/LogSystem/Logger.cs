/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Services.LogSystem
{
    public class Logger : ILogger
    {
        private string m_name;
        private ILoggerImpl? m_loggerImpl;

        public Logger(string name)
        {
            m_name = name;
        }

        public void Init(bool writeToFile, bool tested = false)
        {
            m_loggerImpl = new LoggerImpl(writeToFile, tested);
            m_loggerImpl.Init();
        }

        public void Destroy()
        {
            m_loggerImpl?.Destroy();
        }
        public void Logging(string message, LogLevel level)
        {
            m_loggerImpl?.Write($" {m_name}: {message}", level);
        }
    }
}
