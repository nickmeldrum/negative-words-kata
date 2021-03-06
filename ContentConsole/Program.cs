﻿using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string [] args)
        {
            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var reporter = new BadWordReporter(new ConsoleLogger());

            if (args.Length == 1 && args[0] == "disable")
                reporter.DisableFiltering();

            reporter.Report(content, new[] { "swine", "bad", "nasty", "horrible" });

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
