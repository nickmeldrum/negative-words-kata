namespace ContentConsole
{
    using System.Collections.Generic;
    using System.Linq;

    public class BadWordScanner
    {
        private readonly string[] wordList;

        public BadWordScanner(): this(new[] { "swine", "bad", "nasty", "horrible" })
        {
        }

        public BadWordScanner(IEnumerable<string> wordList)
        {
            this.wordList = wordList.ToArray();
        }

        public int Scan(string phrase)
        {
            var badWords = 0;

            foreach (var word in wordList)
            {
                if (phrase.Contains(word))
                {
                    badWords = badWords + 1;
                }
            }

            return badWords;
        }
    }
}