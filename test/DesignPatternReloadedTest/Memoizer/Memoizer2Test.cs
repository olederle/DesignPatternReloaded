using DesignPatternReloaded.Extensions;
using DesignPatternReloaded.Memoizer;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace DesignPatternReloadedTest.Memoizer
{

    // The memoizer tests must not be executed in parallel because we redirect stdout.
    [Collection("StdOutTestCollection")]
    public class Memoizer2Test
    {

        [Fact]
        public void Test_Memoizer2()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Memoizer2.Memoizer<int, int> memoizer = Memoizer2.CreateMemoizer();

            Enumerable.Range(0, 20).Select(memoizer.Memoize).ForEach(Console.WriteLine);

            stringWriter.Close();

            Assert.Equal(
                "1" + Environment.NewLine +
                "1" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine +
                "0" + Environment.NewLine,
                stringWriter.GetStringBuilder().ToString());
        }

    }

}