/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Services.LogSystem
{
    internal interface ILoggerImpl
    {
        void Init();
        void Destroy();
        void Write(string message, LogLevel level);
    }
}
