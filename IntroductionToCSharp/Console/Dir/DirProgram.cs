namespace Dir
{
    public static class DirProgram
    {
        public static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            if (args.Length > 0)
            {
                dir = args[0];
            }

            var dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                throw new Exception($"Could not find directory {dir}");
            }

            foreach (var fi in dirInfo.GetFiles())
            {
                Console.WriteLine(
                    $"File {fi.Name} was created on {fi.CreationTimeUtc} and is {fi.Length} bytes");
            }
        }
    }
}
