using System;
using System.Collections.Generic;

namespace AddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a bunch of numbers, followed by a blank line when you are done");

            var list = new List<double>();
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                try
                {
                    list.Add(double.Parse(line)); 
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to parse number {line}, message was {e.Message}");
                } 
            }

            var sum = 0.0;
            foreach (var val in list)
            {
                sum += val;
            }
            var n = list.Count;
            var avg = n > 0 ? sum / n : 0.0;

            Console.WriteLine($"The sum of the {n} numbers was {sum} and the average was {avg}"); 
        }
    }
}
