using DesignPatternReloaded.Logger;
using Xunit;
using static DesignPatternReloaded.Logger.Logger3;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger3Test
    {

        [Fact]
        public void Test_Logger3()
        {
            string logOutput;

            Logger3.Logger logger = new Logger3.Logger(msg => logOutput = msg);

            logOutput = null;
            logger.Log("hello");
            Assert.Equal("hello", logOutput);

            FilterLogger filterLogger = new FilterLogger(logger, new Filter(s => s.StartsWith("hell")));

            logOutput = null;
            filterLogger.Log("hello");
            Assert.Equal("hello", logOutput);

            logOutput = null;
            filterLogger.Log("ok");
            Assert.Null(logOutput);
        }

    }

}