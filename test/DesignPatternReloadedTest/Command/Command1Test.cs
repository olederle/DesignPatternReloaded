using System;
using System.IO;
using Xunit;
using static DesignPatternReloaded.Command.Command1;

namespace DesignPatternReloadedTest.Command
{

    // The command tests must not be executed in parallel because we redirect stdout.
    [Collection("StdOutTestCollection")]
    public class Command1Test
    {

        [Fact]
        public void Test_Command1()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Options.Parse(new string[] { "-a" });
            stringWriter.Close();

            Assert.Equal("see -a" + Environment.NewLine, 
                stringWriter.GetStringBuilder().ToString());


            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Options.Parse(new string[] { "-foobar" });
            stringWriter.Close();

            Assert.Equal("a: print all info" 
                + Environment.NewLine 
                + "help: print this help"
                + Environment.NewLine,
                stringWriter.GetStringBuilder().ToString());
        }

    }

}