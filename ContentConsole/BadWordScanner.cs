namespace ContentConsole
{
    using System.Collections.Generic;
    using System.Linq;

    public class BadWordScanner
    {
        private readonly string[] wordList;

        public BadWordScanner(IEnumerable<string> wordList)
        {
            this.wordList = wordList.ToArray();
        }

        public int Scan(string phrase)
        {
            return wordList.Count(phrase.Contains);
        }
    }
}