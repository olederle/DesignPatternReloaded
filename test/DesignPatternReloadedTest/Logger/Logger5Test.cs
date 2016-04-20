using DesignPatternReloaded.Logger;
using Xunit;
using static DesignPatternReloaded.Logger.Logger5;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger5Test
    {

        [Fact]
        public void Test_Logger5()
        {
            string logOutput;

            Log log = msg => logOutput = msg;

            logOutput = null;
            log("hello");
            Assert.Equal("hello", logOutput);

            Filter filter = msg => msg.StartsWith("hell");
            Log filterLog = log.Filter(filter);

            logOutput = null;
            filterLog("hello");
            Assert.Equal("hello", logOutput);

            logOutput = null;
            filterLog("ok");
            Assert.Null(logOutput);
        }

    }

}