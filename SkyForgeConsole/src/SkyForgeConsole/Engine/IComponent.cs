/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole.Engine
{
    public interface IComponent
    {
        IGameObject GameObject { get; set; }
        bool IsActive { get; }
        void Start();
        void OnUpdate();
        void OnEvent(Event e);
        void OnDestroy();
    }
}
