/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;

namespace SkyForgeConsoleTest.Services.FileSystem
{
    internal class FileSystemTest
    {
        [Test]
        public void TestCreateDerectory()
        {
            var directoryName = "TestDirectory";
            if (Directory.Exists(directoryName))
            {
                Directory.Delete(directoryName, true);
            }
            SkyForgeConsole.Services.FileSystem.CreateDirectory(directoryName);
            Assert.IsTrue(Directory.Exists(directoryName));
            Directory.Delete(directoryName, true);
        }

        [Test]
        public void TestIsHaveDirectory()
        {
            var directoryName = "TestDirectory";
            Directory.CreateDirectory(directoryName);
            Assert.IsTrue(SkyForgeConsole.Services.FileSystem.IsHaveDirectory(directoryName));
            Directory.Delete(directoryName, true);
        }

        [Test]
        public void TestIsHaveFile()
        {
            var fileName = "TestFile.txt";
            if (!Path.Exists(fileName))
            {
                Thread thread = new Thread(_ => CreateFile(fileName));
                thread.Start();
                Thread.Sleep(100);
            }
            Assert.IsTrue(SkyForgeConsole.Services.FileSystem.IsHaveFile(fileName));         
        }

        [Test]
        public void TestGetCurrentDirecotry()
        {
            Assert.IsTrue(Directory.GetCurrentDirectory().
                          Equals(SkyForgeConsole.Services.FileSystem.GetCurrentDirectory()));
        }

        [Test]
        public void TestGetFullPath()
        {
            var path = Directory.GetCurrentDirectory();
            Assert.IsTrue(Path.GetFullPath(path).
                          Equals(SkyForgeConsole.Services.FileSystem.GetFullPath(path)));    
        }
        private void CreateFile(string fileName)
        {
            File.Create(fileName);
        }
    }
}
