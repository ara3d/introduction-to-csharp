using System;

namespace HelloWhoAreYou
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what's your name!");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello {name}, nice to meet you!");
        }
    }
}
