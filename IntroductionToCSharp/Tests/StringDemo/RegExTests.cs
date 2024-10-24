using System.Text.RegularExpressions;

namespace DemosAndTests
{

    public static class RegExTests
    {
        public static string InputFile = TestFiles.GetTestFilePath("haus.ifc");

        public const int Id = 14;

        [Test]
        public static void FindDefinition()
        {
            var fileInput = File.ReadAllText(InputFile);

            var regex = new Regex($@"^#{Id}\W*=\W*(.*)$", RegexOptions.Multiline);
            var matches = regex.Matches(fileInput);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Found match: {match}");
                var group = match.Groups[1];
                Console.WriteLine($"Captured Group: {group}");
            }
        }

        [Test]
        public static void FindDefinitionEasier()
        {
            var lines = File.ReadAllLines(InputFile);
            var pattern = $"#{Id}=";
            foreach (var line in lines)
            {
                if (line.StartsWith(pattern))
                {
                    var restOfLine = line.Substring(pattern.Length);
                    Console.WriteLine($"Found match: {line}");
                    Console.WriteLine($"Captured Group: {restOfLine}");
                }
            }
        }
    }
}
