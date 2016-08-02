namespace ContentConsole
{
    public class BadWordScanner
    {
        public int Scan(string phrase)
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            int badWords = 0;
            if (phrase.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (phrase.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }

            return badWords;
        }
    }
}