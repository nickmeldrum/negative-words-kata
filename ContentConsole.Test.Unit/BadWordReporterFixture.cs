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

            reporter.Report("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.");

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == "Total Number of negative words: 2")));
        }

        [Test]
        public void PhraseIsOutput()
        {
            var mockLogger = new Mock<ILogger>();
            var reporter = new BadWordReporter(mockLogger.Object);

            reporter.Report("a phrase");

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == "a phrase")));
        }

        [Test]
        public void PhraseIsOutputWithBadWordsFilteredOut()
        {
            var mockLogger = new Mock<ILogger>();
            var reporter = new BadWordReporter(mockLogger.Object);

            reporter.Report("a bad phrase", new[] { "bad" });

            mockLogger.Verify(t => t.Output(It.Is<string>(msg => msg == "a b#d phrase")));
        }
    }
}
