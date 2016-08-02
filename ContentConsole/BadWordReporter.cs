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
            throw new System.NotImplementedException();
        }
    }
}
