using DesignPatternReloaded.State;
using Xunit;

namespace DesignPatternReloadedTest.State
{

    public class State4Test
    {

        [Fact]
        public void Test_State2()
        {
            string logOutput;

            State4.Logger logger = State4.Logger.Create(msg => logOutput = msg);

            logOutput = null;
            logger.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            logger.Warning("WARNING");
            Assert.Equal("WARNING", logOutput);


            State4.Logger quiet = logger.Quiet();

            logOutput = null;
            quiet.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            quiet.Warning("WARNING");
            Assert.Null(logOutput);


            State4.Logger logger2 = quiet.Chatty();

            logOutput = null;
            logger2.Error("ERROR");
            Assert.Equal("ERROR", logOutput);

            logOutput = null;
            logger2.Warning("WARNING");
            Assert.Equal("WARNING", logOutput);
        }

    }

}