using System;
using System.IO;
using Xunit;
using static DesignPatternReloaded.StructuralTyping.Subtyping;

namespace DesignPatternReloadedTest.StructuralTyping
{

    // The ducktyping tests must not be executed in parallel because we redirect stdout.
    [Collection("StdOutTestCollection")]
    public class SubtypingTest
    {

        [Fact]
        public void Test_Subtyping()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Print(new A());
            stringWriter.Close();
            Assert.Equal("A::M" + Environment.NewLine, stringWriter.GetStringBuilder().ToString());

            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Print(new B());
            stringWriter.Close();
            Assert.Equal("B::M" + Environment.NewLine, stringWriter.GetStringBuilder().ToString());
        }

    }

}