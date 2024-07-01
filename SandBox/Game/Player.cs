/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Engine;
using SkyForgeConsole.Events;
using SkyForgeConsole.Services.LogSystem;

namespace SandBox
{
    internal class Player : IComponent
    {
        public IGameObject GameObject { get; set; }

        public bool IsActive { get; }

        public void OnDestroy()
        {
            Log.ClientLogger?.Logging("Player Destroy", LogLevel.Info);
        }
        public void MovePlayer()
        {
            Console.WriteLine("PLayer move");
        }
        public void OnEvent(Event e)
        {
            
        }

        public void OnUpdate()
        {
            
        }

        public void Start()
        {
            Log.ClientLogger?.Logging("Start Player Script", LogLevel.Info);
        }
    }
}
