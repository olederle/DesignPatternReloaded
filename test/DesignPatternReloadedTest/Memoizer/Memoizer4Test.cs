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
    public class Memoizer4Test
    {

        [Fact]
        public void Test_Memoizer4()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Func<int, int> fibo = Memoizer4.CreateFibo();

            Enumerable.Range(0, 20).Select(fibo).ForEach(Console.WriteLine);

            stringWriter.Close();

            Assert.Equal(
                "1" + Environment.NewLine +
                "1" + Environment.NewLine +
                "2" + Environment.NewLine +
                "3" + Environment.NewLine +
                "5" + Environment.NewLine +
                "8" + Environment.NewLine +
                "13" + Environment.NewLine +
                "21" + Environment.NewLine +
                "34" + Environment.NewLine +
                "55" + Environment.NewLine +
                "89" + Environment.NewLine +
                "144" + Environment.NewLine +
                "233" + Environment.NewLine +
                "377" + Environment.NewLine +
                "610" + Environment.NewLine +
                "987" + Environment.NewLine +
                "1597" + Environment.NewLine +
                "2584" + Environment.NewLine +
                "4181" + Environment.NewLine +
                "6765" + Environment.NewLine,
                stringWriter.GetStringBuilder().ToString());
        }

    }

}