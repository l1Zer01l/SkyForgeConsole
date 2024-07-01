/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Engine;
using SkyForgeConsole.Events;
using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Services.LogSystem;

namespace SandBox
{
    internal class ScriptTest : IComponent
    {
        public IGameObject GameObject { get; set; }

        public bool IsActive { get; private set; }
        private Player m_player;
        public void OnDestroy()
        {
            
        }

        public void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyPressedEvent)
            {
                if (keyPressedEvent.IsPressedKey(KeyCode.R))
                    Console.WriteLine("Component Pressed R");
                if (keyPressedEvent.IsPressedKey(KeyCode.S))
                    m_player.MovePlayer();
            }
        }

        public void OnUpdate()
        {
            
        }

        public void Start()
        {
            Log.ClientLogger?.Logging("Start ScriptTest", LogLevel.Info);
            m_player = GameObject.GetComponent<Player>();
            GameObject.AddComponent(new Player());
        }
    }
}
