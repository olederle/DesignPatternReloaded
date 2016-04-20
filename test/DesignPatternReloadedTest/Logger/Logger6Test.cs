using DesignPatternReloaded.Logger;
using System;
using Xunit;
using static DesignPatternReloaded.Logger.Logger6;

namespace DesignPatternReloadedTest.Logger
{

    public class Logger6Test
    {

        [Fact]
        public void Test_Logger6()
        {
            string logOutput;

            Log log = msg => logOutput = msg;

            logOutput = null;
            log("hello");
            Assert.Equal("hello", logOutput);

            Predicate<string> filter = msg => msg.StartsWith("hell");
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