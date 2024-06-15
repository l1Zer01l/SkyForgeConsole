/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Services.LogSystem
{
    public interface ILogger
    {
        void Init(bool writeToFile, bool tested = false);
        void Destroy();
        void Logging(string message, LogLevel level);
    }
}
