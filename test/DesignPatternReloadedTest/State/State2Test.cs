using Xunit;
using static DesignPatternReloaded.State.State2;

namespace DesignPatternReloadedTest.State
{

    public class State2Test
    {

        [Fact]
        public void Test_State2()
        {
            string logOutput;

            ILogger logger = Loggers.Logger(msg => logOutput = msg);

            logOutput = null;
            logger.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            logger.Warning("WARNING");
            Assert.Equal("WARNING", logOutput);


            ILogger quiet = logger.Quiet();

            logOutput = null;
            quiet.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            quiet.Warning("WARNING");
            Assert.Null(logOutput);


            ILogger logger2 = quiet.Chatty();

            logOutput = null;
            logger2.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            logger2.Warning("WARNING");
            Assert.Equal("WARNING", logOutput);
        }

    }

}