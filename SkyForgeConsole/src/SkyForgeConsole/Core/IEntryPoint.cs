/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Core
{
    public interface IEntryPoint
    {
        void Init(IApplication application);
        IApplication? GetApplication();
        void Destroy();
    }
}