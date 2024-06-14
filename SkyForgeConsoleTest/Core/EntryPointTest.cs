/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Core;

namespace SkyForgeConsoleTest.Core
{
    public class EntryPointTest
    {
        [Test]
        public void CheckCalledApplicationInit()
        {
            IEntryPoint entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = new FakeApplication();
            entryPoint.Init(fakeApplication);
            fakeApplication.CheckCalledApplicationInit(1);
        }

        internal interface IFakeApplication : IApplication
        {
            void CheckCalledApplicationInit(int countCalled);
        }

        internal class FakeApplication : IFakeApplication
        {
            public bool isRunning { get; }

            private int m_countCalledInit = 0;

            public void CheckCalledApplicationInit(int countCalled)
            {
                Assert.That(m_countCalledInit, Is.EqualTo(countCalled));
            }

            public void Exit()
            {

            }

            public void Init()
            {
                m_countCalledInit++;
            }

            public void Run()
            {

            }
        }

    }
    

}
