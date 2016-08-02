namespace ContentConsole
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Output(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
