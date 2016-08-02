namespace ContentConsole
{
    using System.Collections.Generic;
    using System.Text;

    public class BadWordReporter
    {
        private readonly ILogger logger;

        public BadWordReporter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Report(string phrase, string[] wordList)
        {
            var scanner = new BadWordScanner(wordList);
            var numbers = scanner.Scan(phrase);
            logger.Output("Scanned the text:");
            logger.Output("Total Number of negative words: " + numbers);
            logger.Output(HashedPhrase(phrase, wordList));
        }

        private string HashedPhrase(string phrase, IEnumerable<string> wordList)
        {
            var hashedPhrase = phrase;

            foreach (var badWord in wordList)
            {
                hashedPhrase = hashedPhrase.Replace(badWord, new string(new [] {badWord[0], '#', badWord[badWord.Length - 1]}));
            }

            return hashedPhrase;
        }
    }
}
