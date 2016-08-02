using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main()
        {
            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var reporter = new BadWordReporter(new ConsoleLogger());

            reporter.Report(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + "number");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
