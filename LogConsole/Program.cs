/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using LogConsole.Core;

namespace LogConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleLog console = new ConsoleLog();
            console.Init();
            console.Run();
        }
    }
}
