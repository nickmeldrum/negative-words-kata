namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    [TestFixture]
    public class BadWordScannerFixture
    {
        [Test]
        [TestCase("", 0)]
        [TestCase("a lovely phrase", 0)]
        [TestCase("a bad bad bad bad nasty horrible swine of a phrase but repeated words only count once", 4)]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        public void PhraseHasExpectedNumberOfNegativeWords(string phrase, int expectedNumberOfNegativeWords)
        {
            var scanner = new BadWordScanner(new[] { "swine", "bad", "nasty", "horrible" });

            var numberOfNegativeWords = scanner.Scan(phrase);

            Assert.That(numberOfNegativeWords, Is.EqualTo(expectedNumberOfNegativeWords));
        }

        [Test]
        [TestCase(new[] { "lorem" }, "lorem ipsum", 1)]
        [TestCase(new[] { "lorem" }, "no bad words", 0)]
        [TestCase(new[] { "lorem", "ipsum", "bacon", "porkchop" }, "lorem ipsum bacon vegetarian", 3)]
        [TestCase(new[] { "lorem", "ipsum", "bacon", "porkchop", "more" }, "lorem ipsum bacon vegetarian", 3)]
        [TestCase(new[] { "lorem", "ipsum", "bacon", "porkchop", "more" }, "lorem ipsum bacon vegetarian more", 4)]
        public void NegativeWordsSuppliedAreScanned(string[] wordList, string phrase, int expectedNumberOfNegativeWords)
        {
            var scanner = new BadWordScanner(wordList);

            var numberOfNegativeWords = scanner.Scan(phrase);

            Assert.That(numberOfNegativeWords, Is.EqualTo(expectedNumberOfNegativeWords));
        }
    }
}
