/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole.Engine
{
    public interface IScene
    {
        void Init(SceneData data);
        void Start();
        void OnEvent(Event e);
        void OnUpdate();
        void AddGameObject(IGameObject gameObject);
        void RemoveGameObject(IGameObject gameObject);
        SceneData SaveScene();
        void OnDestroy();
    }
}
