/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Core;
using SkyForgeConsole.Engine;
using SkyForgeConsole.Events;
using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Services.LogSystem;

namespace SandBox
{
    internal class ExampleLayer : Layer
    {
        private Layer m_uILayer;
        private Scene? m_currentScene;
        public ExampleLayer(Layer uILayer) : base("Example Layer")
        {
            m_uILayer = uILayer;
        }

        public override void OnAttach()
        {
            Log.ClientLogger?.Logging("Create Example Layer", LogLevel.Info);
            var gameObjects = new List<IGameObject>();

            var emptyGameObject = new EmptyGameObject();
            emptyGameObject.AddComponent(new ScriptTest());
            emptyGameObject.AddComponent(new Player());
            gameObjects.Add(emptyGameObject);

            var sceneData = new SceneData(1, "testScene", gameObjects);
            m_currentScene = new Scene();
            m_currentScene.Init(sceneData);
            m_currentScene.Start();
        }

        public override void OnDetach()
        {
            m_currentScene?.OnDestroy();
        }

        public override void OnEvent(Event e)
        {
            if (e.IsEventCategory(EventCategory.InputEvent))
            {
                m_currentScene?.OnEvent(e);

                if (e is KeyPressedEvent keyPressedEvent)
                {
                    if (keyPressedEvent.IsPressedKey(KeyCode.W))
                        Console.WriteLine("Example Layer");

                    if (keyPressedEvent.IsPressedKey(KeyCode.O))
                        m_uILayer.IsActive = true;
                }
            }
            
        }

        public override void OnUpdate()
        {
            m_currentScene?.OnUpdate();
        }
    }
}
