/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Core;
using SkyForgeConsole.Events;

namespace SkyForgeConsoleTest.Core
{
#if UNITTEST
    internal class LayerStackTest
    {
        [Test]
        public void AddLayerInStackTest()
        {
            var layerStack = new LayerStack();
            var fakeLayer = new FakeLayer("fakeLayer");
            layerStack.PushLayer(fakeLayer);
            Assert.That(layerStack.GetLayer(0).ToString(), Is.EqualTo("fakeLayer"));
            fakeLayer.CheckCalledOnAttach(1);
        }

        [Test]
        public void RemoveLayerInStackTest()
        {
            var layerStack = new LayerStack();
            var fakeLayer = new FakeLayer("fakelayer");
            layerStack.PushLayer(fakeLayer);
            layerStack.PopLayer(fakeLayer);
            fakeLayer.CheckCalledOnDetach(1);

            Assert.Pass();
        }

        [Test]
        public void RemoveLayerInStackTestWhenNotLayerIsStack()
        {
            var layerStack = new LayerStack();
            Assert.Throws<InvalidOperationException>(() => layerStack.PopLayer(new FakeLayer("fakeLayer")), "Can't Find Layer: fakeLayer in LayerStack");
        }

        [Test]
        public void GetLayerInStackTestWhenIndexOverStackCount()
        {
            var layerStack = new LayerStack();
            Assert.Throws<IndexOutOfRangeException>(() => layerStack.GetLayer(10), "index: 10 out of range Exeption in LayerStack");
            Assert.Throws<IndexOutOfRangeException>(() => layerStack.GetLayer(-1), "index: -1 out of range Exeption in LayerStack");
        }

        [Test]
        public void AddOverlayInStackTest()
        {
            var layerStack = new LayerStack();
            var fakeLayer = new FakeLayer("fakeLayer");
            layerStack.PushOverlay(fakeLayer);
            Assert.That(layerStack.GetOverlay(0).ToString(), Is.EqualTo("fakeLayer"));
            fakeLayer.CheckCalledOnAttach(1);
        }

        [Test]
        public void RemoveOverlayInStackTest()
        {
            var layerStack = new LayerStack();
            var fakeLayer = new FakeLayer("fakelayer");
            layerStack.PushOverlay(fakeLayer);
            layerStack.PopOverlay(fakeLayer);
            fakeLayer.CheckCalledOnDetach(1);

            Assert.Pass();
        }

        [Test]
        public void RemoveOverlayInStackTestWhenNotOverlayIsStack()
        {
            var layerStack = new LayerStack();
            Assert.Throws<InvalidOperationException>(() => layerStack.PopLayer(new FakeLayer("fakeLayer")), "Can't Find Layer: fakeLayer in LayerStack");
        }

        [Test]
        public void GetOverlayInStackTestWhenIndexOverStackCount()
        {
            var layerStack = new LayerStack();
            Assert.Throws<IndexOutOfRangeException>(() => layerStack.GetOverlay(10), "index: 10 out of range Exeption in LayerStack");
            Assert.Throws<IndexOutOfRangeException>(() => layerStack.GetOverlay(-1), "index: -1 out of range Exeption in LayerStack");
        }


        [Test]
        public void CheckOverLayUpperLayerWhenGetLayers()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new FakeLayer("1");
            var fakeLayer2 = new FakeLayer("2");
            layerStack.PushOverlay(fakeLayer2);
            layerStack.PushLayer(fakeLayer1);
            var layers = layerStack.GetLayers();
            Assert.IsTrue(layers.Length.Equals(2));
            Assert.IsTrue(layers[0].ToString().Equals("1"));
            Assert.IsTrue(layers[1].ToString().Equals("2"));
        }

        [Test]
        public void CheckOverLayUpperLayerWhenGetLayersReverse()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new FakeLayer("1");
            var fakeLayer2 = new FakeLayer("2");
            layerStack.PushOverlay(fakeLayer2);
            layerStack.PushLayer(fakeLayer1);
            var layers = layerStack.GetLayersReverse();
            Assert.IsTrue(layers.Length.Equals(2));
            Assert.IsTrue(layers[0].ToString().Equals("2"));
            Assert.IsTrue(layers[1].ToString().Equals("1"));
        }

    }

    internal class FakeLayer : Layer
    {
        private int m_countCalledOnAttach = 0;
        private int m_countCalledOnDetach = 0;
        public FakeLayer(string name) :  base(name) { }
        public override void OnAttach()
        {
            m_countCalledOnAttach++;
        }

        public override void OnDetach()
        {
            m_countCalledOnDetach++;
        }

        public override void OnEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public void CheckCalledOnAttach(int countCalled)
        {
            Assert.IsTrue(m_countCalledOnAttach.Equals(countCalled));
        }
        public void CheckCalledOnDetach(int countCalled)
        {
            Assert.IsTrue(m_countCalledOnDetach.Equals(countCalled));
        }
    }
#endif
}
