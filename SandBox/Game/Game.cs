/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Core;

namespace SandBox
{
    internal class Game : Application
    {
        protected override void OnInit()
        {
            var uILayer = new UILayer();
            PushOverlay(uILayer);
            PushLayer(new ExampleLayer(uILayer));
        }

        protected override void OnDestroy()
        {
            
        }
    }
}
