/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsole.Core
{
#if UNITTEST
    public class LayerStack
#else
    internal class LayerStack
#endif
    {
        private List<Layer> m_layers;
        private List<Layer> m_overlays;

        public LayerStack()
        {
            m_layers = new List<Layer>();
            m_overlays = new List<Layer>();
        }

        public void PushLayer(Layer layer)
        {
            m_layers.Add(layer);
            layer.OnAttach();
        }

        public void PushOverlay(Layer overlay)
        {
            m_overlays.Add(overlay);
            overlay.OnAttach();
        }

        public void PopLayer(Layer layer)
        {
            int index = m_layers.FindIndex(i => ReferenceEquals(i, layer));
            if (index < 0)
            {
                Log.CoreLogger?.Logging($"Can't Find Layer: {layer} in LayerStack", LogLevel.Error);
                throw new InvalidOperationException($"Can't Find Layer: {layer} in LayerStack");
            }
            m_layers.RemoveAt(index);
            layer.OnDetach();
        }

        public void PopOverlay(Layer overlay)
        {
            int index = m_overlays.FindIndex(i => ReferenceEquals(i, overlay));
            if (index < 0)
            {
                Log.CoreLogger?.Logging($"Can't Find Layer: {overlay} in LayerStack", LogLevel.Error);
                throw new InvalidOperationException($"Can't Find Layer: {overlay} in LayerStack");
            }
            m_overlays.RemoveAt(index);
            overlay.OnDetach();
        }

        public Layer GetLayer(int index)
        {
            if (index < 0 || index >= m_layers.Count)
            {
                Log.CoreLogger?.Logging($"index: {index} out of range Exeption in LayerStack", LogLevel.Error);
                throw new IndexOutOfRangeException($"index: {index} out of range Exeption in LayerStack");
            }
            return m_layers[index];
        }

        public Layer GetOverlay(int index)
        {
            if (index < 0 || index >= m_overlays.Count)
            {
                Log.CoreLogger?.Logging($"index: {index} out of range Exeption in LayerStack", LogLevel.Error);
                throw new IndexOutOfRangeException($"index: {index} out of range Exeption in LayerStack");
            }
            return m_overlays[index];
        }

        public Layer[] GetLayers()
        {
            return m_layers.Concat(m_overlays).ToArray();
        }

        public Layer[] GetLayersReverse()
        {
            return m_layers.Concat(m_overlays).Reverse().ToArray();
        }
    }
}
