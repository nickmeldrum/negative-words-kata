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
    }
}
