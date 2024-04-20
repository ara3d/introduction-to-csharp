namespace Lab2Sort
{
    public static class Program
    {
        public static IEnumerable<string> ReadAllLines()
        {
            var s = Console.ReadLine();
            while (s != null)
            {
                yield return s;
                s = Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            var lines = ReadAllLines();
            foreach (var line in lines.OrderBy(s => s))
            {
                Console.WriteLine(line);
            }
        }
    }
}