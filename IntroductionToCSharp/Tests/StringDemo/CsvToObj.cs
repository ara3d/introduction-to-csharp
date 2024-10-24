using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemosAndTests
{
    public static class CsvToObjTest
    {
        [Test, Explicit]
        public static void CsvToObj()
        {
            var inputFile = TestFiles.GetTestFilePath("geometry.csv");
            var inputLines = File.ReadAllLines(inputFile);
            var outputLines = new List<string>();
            
            
            // Output the vertices 
            foreach (var line in inputLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var parts = line.Split(',');
                var x = double.Parse(parts[0]);
                var y = double.Parse(parts[1]);
                var z = double.Parse(parts[2]);
                outputLines.Add($"v {x} {y} {z}");
            }

            // Output the face indices 
            for (var i = 0; i < inputLines.Length; i += 3)
            {
                // Note: OBJ files use a "1" based indexing to indicate the vertices of a face
                outputLines.Add($"f {i + 1} {i + 2} {i + 3}");
            }

            var outputFile = TestFiles.GetTestFilePath("geometry.obj");
            File.WriteAllLines(outputFile, outputLines);
        }
    }
}
