/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Core
{
    public interface IApplication
    {
        bool IsRunning { get; }
        void Init();
        void Run();
        void Exit();
    }
}