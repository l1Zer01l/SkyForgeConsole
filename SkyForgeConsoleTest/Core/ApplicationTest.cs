/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Core;

namespace SkyForgeConsoleTest.Core
{
    internal class ApplicationTest
    {
        [Test]
        public void TestInit()
        {
            var fakeGame = new FakeGame();
            fakeGame.Init();
            Assert.IsTrue(fakeGame.isRunning);
        }

        [Test]
        public void TestExit()
        {
            var fakeGame = new FakeGame();
            fakeGame.Init();
            Assert.IsTrue(fakeGame.isRunning);
            fakeGame.Exit();
            Assert.IsFalse(fakeGame.isRunning);
        }

        [Test]
        public void TestRunWhenNotCalledInit()
        {
            var fakeGame = new FakeGame();
            Assert.Throws<MethodAccessException>(fakeGame.Run, "don't called Init or Application disable");
        }

        [Test]
        public void TestRunWhenCalledExitAfterInit()
        {
            var fakeGame = new FakeGame();
            fakeGame.Init();
            fakeGame.Exit();
            Assert.Throws<MethodAccessException>(fakeGame.Run, "don't called Init or Application disable");
        }

        [Test]
        public void TestCalledOnInit()
        {
            var fakeGame = new FakeGame();
            fakeGame.Init();
            fakeGame.CheckCalledOnInit(1);
        }
    }

    internal class FakeGame : Application
    {
        private int m_countCalled = 0;
        internal void CheckCalledOnInit(int countCalled)
        {
            Assert.IsTrue(m_countCalled == countCalled);
        }
        protected override void OnInit()
        {
            m_countCalled++;
        }
    }
}
