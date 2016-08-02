namespace ContentConsole
{
    using System.Collections.Generic;

    public class BadWordReporter
    {
        private readonly ILogger logger;
        private bool filteringDisabled = false;

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

            logger.Output(filteringDisabled ? phrase : HashedPhrase(phrase, wordList));
        }

        private string HashedPhrase(string phrase, IEnumerable<string> wordList)
        {
            var hashedPhrase = phrase;

            foreach (var badWord in wordList)
            {
                var hashedWord = new string(new [] {badWord[0]});
                if (badWord.Length > 2)
                    hashedWord += new string('#', badWord.Length - 2);
                if (badWord.Length > 1)
                    hashedWord += new string(new[] {badWord[badWord.Length - 1]});
                hashedPhrase = hashedPhrase.Replace(badWord, hashedWord);
            }

            return hashedPhrase;
        }

        public void DisableFiltering()
        {
            filteringDisabled = true;
        }
    }
}
