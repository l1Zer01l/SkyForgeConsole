/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Core;
using SkyForgeConsole.Events;
using SkyForgeConsole.Services.Input;
using SkyForgeConsole.Services.LogSystem;

namespace SandBox
{
    internal class ExampleLayer : Layer
    {
        private Layer m_uILayer;
        public ExampleLayer(Layer uILayer) : base("Example Layer")
        {
            m_uILayer = uILayer;
        }

        public override void OnAttach()
        {
            Log.ClientLogger?.Logging("Create Example Layer", LogLevel.Info);
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
                        Console.WriteLine("Example Layer");

                    if (keyPressedEvent.IsPressedKey(KeyCode.O))
                        m_uILayer.IsActive = true;
                }
            }
        }

        public override void OnUpdate()
        {
            
        }
    }
}
