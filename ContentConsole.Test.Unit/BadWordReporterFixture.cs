namespace ContentConsole.Test.Unit
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class BadWordReporterFixture
    {
        [Test]
        public void NumberOfNegativeWordsIsOutput()
        {
            var mockLogger = new Mock<ILogger>();
            var reporter = new BadWordReporter(mockLogger.Object);

            reporter.Report("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", new[] { "swine", "bad", "nasty", "horrible" });

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == "Total Number of negative words: 2")));
        }

        [Test]
        public void PhraseIsOutput()
        {
            var mockLogger = new Mock<ILogger>();
            var reporter = new BadWordReporter(mockLogger.Object);

            reporter.Report("a phrase", new[] { "swine", "bad", "nasty", "horrible" });

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == "a phrase")));
        }

        [Test]
        [TestCase(new[] { "bad" }, "a bad phrase", "a b#d phrase")]
        [TestCase(new[] { "bad", "horrible" }, "a horrible phrase", "a h######e phrase")]
        [TestCase(new[] { "to" }, "phrase with a short bad word that is to", "phrase with a short bad word that is to")]
        [TestCase(new[] { "I" }, "phrase with a shorter bad word that is I", "phrase with a shorter bad word that is I")]
        public void PhraseIsOutputWithBadWordsFilteredOut(string[] wordList, string phrase, string hashedPhrase)
        {
            var mockLogger = new Mock<ILogger>();
            var reporter = new BadWordReporter(mockLogger.Object);

            reporter.Report(phrase, wordList);

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == hashedPhrase)));
        }
    }
}
