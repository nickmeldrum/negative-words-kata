namespace ContentConsole
{
    public class BadWordReporter
    {
        private readonly ILogger logger;

        public BadWordReporter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Report(string phrase)
        {
            var scanner = new BadWordScanner();
            var numbers = scanner.Scan(phrase);
            logger.Output("Scanned the text:");
            logger.Output("Total Number of negative words: " + numbers);
        }
    }
}
