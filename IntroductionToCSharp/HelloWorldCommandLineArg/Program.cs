﻿using System;

namespace HelloWorldCommandLineArg
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Hello {args[0]}!");
        }
    }
}
