/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Services.LogSystem;

namespace SkyForgeConsoleTest.Services.LogSystem
{
    internal class LogLevelTest
    {
        [Test]
        public void InfoMoreMassage()
        {
            Assert.IsTrue(LogLevel.Info > LogLevel.Massage);
            Assert.IsTrue(LogLevel.Massage < LogLevel.Info);
        }

        [Test]
        public void WarnMoreInfo()
        {
            Assert.IsTrue(LogLevel.Warn > LogLevel.Info);
            Assert.IsTrue(LogLevel.Info < LogLevel.Warn);
        }

        [Test]
        public void ErrorMoreWarn()
        {
            Assert.IsTrue(LogLevel.Error > LogLevel.Warn);
            Assert.IsTrue(LogLevel.Warn < LogLevel.Error);
        }

        [Test]
        public void CriticalMoreError()
        {
            Assert.IsTrue(LogLevel.Critical > LogLevel.Error);
            Assert.IsTrue(LogLevel.Error < LogLevel.Critical);
        }

        [Test]
        public void GetErrorFromLevel()
        {
            var actual = LogLevel.FromLevel(4);
            Assert.IsTrue(LogLevel.Error.Equals(actual));
        }
        [Test]
        public void GetInfoFromLevel()
        {
            var actual = LogLevel.FromLevel(2);
            Assert.IsTrue(LogLevel.Info.Equals(actual));
        }
        [Test]
        public void GetWarnFromLevel()
        {
            var actual = LogLevel.FromLevel(3);
            Assert.IsTrue(LogLevel.Warn.Equals(actual));
        }
        [Test]
        public void GetErrorFromName()
        {
            var actual = LogLevel.FromName(nameof(LogLevel.Error));
            Assert.IsTrue(LogLevel.Error.Equals(actual));
        }
        [Test]
        public void GetInfoFromName()
        {
            var actual = LogLevel.FromName(nameof(LogLevel.Info));
            Assert.IsTrue(LogLevel.Info.Equals(actual));
        }
        [Test]
        public void GetWarnFromName()
        {
            var actual = LogLevel.FromName(nameof(LogLevel.Warn));
            Assert.IsTrue(LogLevel.Warn.Equals(actual));
        }

        [Test]
        public void CheckOverrideToString()
        {
            Assert.That(LogLevel.Info.ToString(), Is.EqualTo(nameof(LogLevel.Info)));
            Assert.That(LogLevel.Warn.ToString(), Is.EqualTo(nameof(LogLevel.Warn)));
            Assert.That(LogLevel.Error.ToString(), Is.EqualTo(nameof(LogLevel.Error)));
        }
    }
}
