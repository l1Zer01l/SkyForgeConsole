/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;
using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Core
{
    public abstract class Layer : IDisposable
    {
        public bool IsActive { get; set; } = true;

        protected string m_debugName;

        public Layer(in string name = "Layer")
        {
            m_debugName = name;
        }

        public void Dispose()
        {
            Log.CoreLogger?.Logging($"Destroy Layer: {m_debugName}", LogLevel.Info);
        }

        public override string ToString() => m_debugName;
        public abstract void OnAttach();
        public abstract void OnDetach();
        public abstract void OnUpdate();
        public abstract void OnEvent(Event e);

        
    }
}
