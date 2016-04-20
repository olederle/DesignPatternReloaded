using System;
using System.IO;
using Xunit;
using static DesignPatternReloaded.StructuralTyping.Structuraltyping;

namespace DesignPatternReloadedTest.StructuralTyping
{

    // The structuraltyping tests must not be executed in parallel because we redirect stdout.
    [Collection("StdOutTestCollection")]
    public class StructuraltypingTest
    {

        [Fact]
        public void Test_Structuraltyping()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Print(new A().M);
            stringWriter.Close();
            Assert.Equal("A::M" + Environment.NewLine, stringWriter.GetStringBuilder().ToString());

            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Print(new B().M);
            stringWriter.Close();
            Assert.Equal("B::M" + Environment.NewLine, stringWriter.GetStringBuilder().ToString());
        }

    }

}