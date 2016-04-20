using Xunit;
using static DesignPatternReloaded.Logger.Logger4;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger4Test
    {

        [Fact]
        public void Test_Logger4()
        {
            string logOutput;

            Log log = msg => logOutput = msg;

            logOutput = null;
            log("hello");
            Assert.Equal("hello", logOutput);

            Filter filter = msg => msg.StartsWith("hell");
            Log filterLog = Loggers.FilterLogger(log, filter);

            logOutput = null;
            filterLog("hello");
            Assert.Equal("hello", logOutput);

            logOutput = null;
            filterLog("ok");
            Assert.Null(logOutput);
        }

    }

}