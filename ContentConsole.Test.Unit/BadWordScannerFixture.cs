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
            var scanner = new BadWordScanner();

            var numberOfNegativeWords = scanner.Scan(phrase);

            Assert.That(numberOfNegativeWords, Is.EqualTo(expectedNumberOfNegativeWords));
        }

        [Test]
        public void NegativeWordsSuppliedAreScanned()
        {
            var scanner = new BadWordScanner(new[] { "lorem", "ipsum", "bacon", "porkchop" });

            var numberOfNegativeWords = scanner.Scan("lorem ipsum bacon vegetarian");

            Assert.That(numberOfNegativeWords, Is.EqualTo(3));
        }
    }
}
