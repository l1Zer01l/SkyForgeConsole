/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Services.LogSystem
{
    internal class LoggerImpl : ILoggerImpl
    {
        private const string BASIC_PATH = @".\Log";

        internal static void SetLogFilePath(string path) => m_filePathLog = path;
        internal bool WriteToFile { get => m_writeToFile; set => m_writeToFile = value; }

        private bool m_writeToFile = true;
        private bool m_tested = false;
        private static string? m_filePathLog;

        internal LoggerImpl(bool writeToFile, bool tested)
        {
            m_tested = tested;
            m_writeToFile = writeToFile;
        }
        public void Init()
        {
            if (m_filePathLog is null)
                m_filePathLog = BASIC_PATH;

            if (!ConsoleLogger.IsInit)
                throw new Exception("Don't Init ConsoleLogger");

            if (m_tested)
            {
                Write("Massage test", LogLevel.Massage);
                Write("Info test", LogLevel.Info);
                Write("Warn test", LogLevel.Warn);
                Write("Error test", LogLevel.Error);
                Write("Critical test", LogLevel.Critical);
                Write("Off test", LogLevel.Off);
            }
        }

        public void Destroy()
        {

        }

        public void Write(string message, LogLevel level)
        {
            if (m_writeToFile)
                WriteToFileLog(message, level);
            WriteToConsoleLog(message, level);
        }
        private static void WriteToConsoleLog(string massage, LogLevel logLevel)
        {
            var resultMassage = Patern(massage, logLevel);
            var color = ConsoleColor.White;
            if (logLevel.Equals(LogLevel.Massage))
                color = ConsoleColor.Blue;
            else if (logLevel.Equals(LogLevel.Info))
                color = ConsoleColor.Green;
            else if (logLevel.Equals(LogLevel.Warn))
                color = ConsoleColor.Yellow;
            else if (logLevel.Equals(LogLevel.Error))
                color = ConsoleColor.Red;
            else if (logLevel.Equals(LogLevel.Critical))
                color = ConsoleColor.DarkRed;
            else if (logLevel.Equals(LogLevel.Off))
                color = ConsoleColor.DarkYellow;
            ConsoleLogger.Write(color, resultMassage);
        }

        private static void WriteToFileLog(string massage, LogLevel logLevel)
        {
            if (string.IsNullOrEmpty(m_filePathLog))
                throw new Exception("filePath is null");

            if (!FileSystem.IsHaveDirectory(m_filePathLog))
                FileSystem.CreateDirectory(m_filePathLog);

            var time = DateTime.Now;
            var fileName = $"log-date({time.Day}_{time.Month}_{time.Year}).txt";

#if (DEBUG || UNITTEST)

            if (logLevel >= LogLevel.Info)
            {
                FileSystem.WriteToFile(Patern(massage, logLevel), FileSystem.CombinePath(m_filePathLog, fileName));
            }
#else
            if (logLevel >= LogLevel.Warn)
            {
                FileSystem.WriteToFile(Patern(massage, logLevel), FileSystem.CombinePath(m_filePathLog, fileName));
            }
#endif
        }

        private static string Patern(in string msg, LogLevel level)
        {
            var time = DateTime.Now;
            return $"[{time.Hour}:{time.Minute}:{time.Second}] -> ({level}) {msg}";
        }
    }
}