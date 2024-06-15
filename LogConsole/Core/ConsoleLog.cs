/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using LogConsole.Vendor.Win32;
using System.IO.Pipes;

namespace LogConsole.Core
{
    public class ConsoleLog : IConsoleLog
    {
        public const string PIPE_NAME = "LogServer";
        public const string FileName = "LogConsole.exe";

        private NamedPipeClientStream? m_pipeClient;
        public void Init()
        {
            m_pipeClient = new NamedPipeClientStream(".", PIPE_NAME, PipeDirection.InOut, PipeOptions.None);
            if (m_pipeClient.IsConnected != true)
                m_pipeClient.Connect();
        }

        public void Run()
        {
            if (m_pipeClient == null)
                throw new Exception("Can't called Init ConsoleLog");

            StreamReader? reader = new StreamReader(m_pipeClient);
            WinApiNative.EnableButtonMenu(WinApiNative.BUTTON_CLOSE, WinApiNative.LB_COMMAND | WinApiNative.LB_DISABLE);
            while (m_pipeClient.IsConnected)
            {
                string[]? line = reader.ReadLine()?.Split(LogConsoleColor.SEPARATOR_COLOR);
                if (line != null)
                {
                    switch (line[0])
                    {
                        case LogConsoleColor.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case LogConsoleColor.Blue:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case LogConsoleColor.Green:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case LogConsoleColor.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case LogConsoleColor.White:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case LogConsoleColor.DarkRed:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case LogConsoleColor.DarkYellow:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(line[1]);
                }
            }
        }
    }
}
