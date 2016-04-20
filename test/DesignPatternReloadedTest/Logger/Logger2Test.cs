using DesignPatternReloaded.Logger;
using Xunit;
using static DesignPatternReloaded.Logger.Logger2;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger2Test
    {

        [Fact]
        public void Test_Logger2()
        {
            string logOutput;

            Logger2.Logger logger = new Logger2.Logger(msg => logOutput = msg);

            logOutput = null;
            logger.Log("hello");
            Assert.Equal("hello", logOutput);

            FilterLogger filterLogger = new ConcreteFilterLogger(logger);

            logOutput = null;
            filterLogger.Log("hello");
            Assert.Equal("hello", logOutput);

            logOutput = null;
            filterLogger.Log("ok");
            Assert.Null(logOutput);
        }

    }

}