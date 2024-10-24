using File = System.IO.File;

namespace SimpleIfcReader
{
    // Programs should always be public and static. 
    // By default they are "internal" and non-static. 
    public static class Program
    {
        // The entry point of the program. 
        public static void Main(string[] args)
        {
            // Check that a command line argument is provided. 
            if (args.Length == 0)
            {
                // If no command line argument is provided let the user know 
                Console.WriteLine("Usage: SimpleIfcReader <filename>");

                // Exit the program. 
                return;
            }

            // A FileInfo struct provide useful information about a file on the file system
            var fileInfo = new FileInfo(args[0]);
            
            // We need to check that the file exists. 
            if (!fileInfo.Exists)
            {
                // Again, if nothing present, let the user know and exit.
                Console.WriteLine($"Could not find file {fileInfo.Name}");
                return;
            }

            // This is a simple way to read all lines from a file.
            var lines = File.ReadAllLines(fileInfo.FullName);
            
            // This will be used as a counter for the number of doors 
            var n = 0;

            // Loop through all the lines in the file.
            foreach (var line in lines)
            {
                // Check if the line has a reference to an IFCDOOR
                if (line.Contains("IFCDOOR"))
                {
                    // Output the line for convenience and increment the counter.
                    Console.WriteLine(line);
                    n++;
                }
            }

            // Output how many doors you found.
            Console.WriteLine($"Found {n} doors");
        }
    }
}
