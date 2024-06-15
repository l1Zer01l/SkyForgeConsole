/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using LogConsole.Core;

namespace SkyForgeConsoleTest.Services.LogSystem
{
    internal class LogConsoleColorTest
    {
        [Test]
        public void CheckNameColor()
        {
            Assert.IsTrue(LogConsoleColor.White.Equals(ConsoleColor.White.ToString()));
            Assert.IsTrue(LogConsoleColor.Red.Equals(ConsoleColor.Red.ToString()));
            Assert.IsTrue(LogConsoleColor.Blue.Equals(ConsoleColor.Blue.ToString()));
            Assert.IsTrue(LogConsoleColor.Green.Equals(ConsoleColor.Green.ToString()));
            Assert.IsTrue(LogConsoleColor.Yellow.Equals(ConsoleColor.Yellow.ToString()));
            Assert.IsTrue(LogConsoleColor.DarkRed.Equals(ConsoleColor.DarkRed.ToString()));
            Assert.IsTrue(LogConsoleColor.DarkYellow.Equals(ConsoleColor.DarkYellow.ToString()));
        }
    }
}
