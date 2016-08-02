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
            int badWords = 0;
            if (phrase.Contains(wordList[0]))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(wordList[1]))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(wordList[2]))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(wordList[3]))
            {
                badWords = badWords + 1;
            }

            return badWords;
        }
    }
}