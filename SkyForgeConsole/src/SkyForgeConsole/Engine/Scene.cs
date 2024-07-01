/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;
using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Engine
{
    public class Scene : IScene
    {
        private string? m_name;
        private List<IGameObject> m_gameObjects;
        public Scene()
        {
            m_gameObjects = new List<IGameObject>();
        }

        public void Init(SceneData data)
        {
            m_name = data.Name;
            m_gameObjects = data.GameObjects;
            Log.ClientLogger?.Logging($"Init scene: {m_name}", LogLevel.Info);
        }

        public void Start()
        {
            foreach (var gameObject in m_gameObjects)
                gameObject.Start();
        }

        public void OnDestroy()
        {
            foreach (var gameObject in m_gameObjects)
            {
                gameObject.OnDestroy();
            }
            m_gameObjects.Clear();
        }

        public void OnEvent(Event e)
        {
            foreach(var gameObject in m_gameObjects)
                gameObject.OnEvent(e);
        }

        public void OnUpdate()
        {
            foreach (var gameObject in m_gameObjects)
                gameObject.OnUpdate();
        }

        public SceneData SaveScene()
        {
            var data = new SceneData(
                id: 1,
                name: m_name ?? string.Empty,
                gameObjects: m_gameObjects
                );
            return data;
        }

        public override string ToString()
        {
            return m_name ?? string.Empty;
        }

        public void AddGameObject(IGameObject gameObject)
        {
            gameObject.Start();
            m_gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            gameObject.OnDestroy();
            m_gameObjects.Remove(gameObject);
        }
    }
}
