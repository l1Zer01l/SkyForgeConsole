/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if (DEBUG || RELEASE)
using SkyForgeConsole.Services.LogSystem;
#endif

namespace SkyForgeConsole.Services
{
    public static class FileSystem
    {
        public static void CreateDirectory(string pathDirectory)
        {
            Directory.CreateDirectory(pathDirectory);
        }
        public static bool IsHaveDirectory(string pathDirectory)
        {
            return Directory.Exists(pathDirectory);
        }
        public static bool IsHaveFile(string filePath)
        {
            return File.Exists(filePath);
        }
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public static string GetFullPath(string directoryName)
        {
            return Path.GetFullPath(directoryName);
        }
        public static string CombinePath(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        public static void WriteToFile(string massage, string filePath)
        {

#if UNITTEST
            return;
#else

            try
            {
                using (var textWriter = File.AppendText(filePath))
                {
                    textWriter.WriteLine(massage);
                }
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't write to file: {filePath}. Exception {ex}", LogLevel.Error);
            }
#endif
        }
        public static List<string>? ReadFromFile(string filePath)
        {

#if UNITTEST
            return null;
#else
            return ReadFromFile(filePath, 0, 0);
#endif
        }
        public static List<string>? ReadFromFile(string filePath, int removeStart, int removeEnd)
        {

#if UNITTEST
            return null;
#else
            if (!IsHaveFile(filePath))
            {
                Log.CoreLogger?.Logging($"Error can't read file: {filePath}. ", LogLevel.Error);
                return null;
            }


            using (var textReader = File.OpenText(filePath))
            {
                var result = new List<string>();
                var textLine = textReader.ReadLine();
                while (textLine != null)
                {
                    result.Add(textLine.Remove(removeStart, removeEnd));
                    textLine = textReader.ReadLine();
                }
                textReader.Close();
                textReader.Dispose();
                return result;
            }
#endif
        }
    }
}
