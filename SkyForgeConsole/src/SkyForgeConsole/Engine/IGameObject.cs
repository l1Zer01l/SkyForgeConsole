/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole.Engine
{
    public interface IGameObject
    {
        bool IsActive { get; }
        void Start();
        void AddComponent(IComponent component);
        void RemoveComponent<TComponent>() where TComponent : class, IComponent;
        void OnUpdate();
        void OnEvent(Event e);
        void OnDestroy();
        TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    }
}
