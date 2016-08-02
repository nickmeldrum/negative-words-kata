namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    [TestFixture]
    public class BadWordScannerFixture
    {
        [Test]
        public void NoWordsInPhraseThenNumberOfNegativeWordsIsZero()
        {
            var scanner = new BadWordScanner();

            var numberOfNegativeWords = scanner.Scan(string.Empty);

            Assert.That(numberOfNegativeWords, Is.EqualTo(0));
        }
    }
}
