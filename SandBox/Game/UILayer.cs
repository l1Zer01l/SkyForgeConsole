/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Core;
using SkyForgeConsole.Events;
using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Services.LogSystem;

namespace SandBox
{
    internal class UILayer : Layer
    {
        public UILayer() : base("UI Layer") 
        { 
            
        }

        public override void OnAttach()
        {
            Log.ClientLogger?.Logging("Create UI Layer", LogLevel.Info);
        }

        public override void OnDetach()
        {
            
        }

        public override void OnEvent(Event e)
        {
            if (e.IsEventCategory(EventCategory.InputEvent))
            {
                if (e is KeyPressedEvent keyPressedEvent)
                {
                    if (keyPressedEvent.IsPressedKey(KeyCode.W))
                        Console.WriteLine("UI Layer");

                    if (keyPressedEvent.IsPressedKey(KeyCode.O))
                        IsActive = false;
                }              
            }
        }

        public override void OnUpdate()
        {
            
        }
    }
}
