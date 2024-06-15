﻿/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Core;

namespace SandBox
{
    internal class Program
    {
        private static void Main()
        {
            IEntryPoint entryPoint = EntryPoint.GetEntryPoint();
            Game game = new Game();
            entryPoint.Init(game);
            game.Run();
            entryPoint.Destroy();
        }
    }
}
