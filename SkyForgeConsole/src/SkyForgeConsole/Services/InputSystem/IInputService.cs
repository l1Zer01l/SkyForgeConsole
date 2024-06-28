/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole.Services.Input
{
    public interface IInputService
    {
        event Action<Event> eventCalled;
        void Init();
        void Destroy();
    }
}
