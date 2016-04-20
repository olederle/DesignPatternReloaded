using Xunit;
using static DesignPatternReloaded.Logger.Logger1;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger1Test
    {

        [Fact]
        public void Test_Logger1()
        {
            string logOutput;

            Log log = msg => logOutput = msg;

            logOutput = null;
            log("hello");
            Assert.Equal("hello", logOutput);
        }

    }

}