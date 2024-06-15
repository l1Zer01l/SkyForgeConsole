/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using LogConsole.Core;
using System.Diagnostics;
using System.IO.Pipes;

namespace SkyForgeConsole.Services.LogSystem
{
    internal class ConsoleLogger
    {
        public static bool IsInit { get; private set; } = false;

        private static StreamWriter? m_writer;
        private static NamedPipeServerStream? m_pipeServer;
        private static Process? m_process;
        internal static void Init()
        {
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = Path.Combine(FileSystem.GetFullPath(FileSystem.GetCurrentDirectory()), ConsoleLog.FileName);
            startinfo.WindowStyle = ProcessWindowStyle.Normal;
            startinfo.UseShellExecute = true;
            
            m_process = new Process();
            m_process.StartInfo = startinfo;
            m_process.Start();

            m_pipeServer = new NamedPipeServerStream(ConsoleLog.PIPE_NAME, PipeDirection.InOut, 4);
            m_pipeServer.WaitForConnection();
            m_writer = new StreamWriter(m_pipeServer);
            IsInit = true;
        }

        internal static void Destroy()
        {
            m_process?.Kill();
        }

        internal static void Write(ConsoleColor color, string message)
        {
            if (m_writer is null)
                throw new Exception("can't write to consoleLog stream write is null");
            if (m_pipeServer is null)
                throw new Exception("don't create consoleLog and Init ConsoleLogger");

            var result = color.ToString() + LogConsoleColor.SEPARATOR_COLOR + message;
            

            m_writer.WriteLine(result);
            m_writer.Flush();

            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
#pragma warning disable CA1416 // Проверка совместимости платформы
                m_pipeServer.WaitForPipeDrain();
#pragma warning restore CA1416 // Проверка совместимости платформы
        }
    }
}
