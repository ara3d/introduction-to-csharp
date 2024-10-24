using System.Runtime.CompilerServices;

namespace DemosAndTests
{
    public static class TestFiles
    {
        public static string GetSourceFolder([CallerFilePath] string callerFilePath = "")
        {
            return Path.GetDirectoryName(callerFilePath) ?? "";
        }

        public static string GetTestFileFolder()
        {
            return Path.Combine(GetSourceFolder(), "..", "..", "..", "TestFiles");
        }

        public static string GetTestFilePath(string fileName)
        {
            return Path.Combine(GetTestFileFolder(), fileName);
        }
    }
}