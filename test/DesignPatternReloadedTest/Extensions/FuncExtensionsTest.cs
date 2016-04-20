using DesignPatternReloaded.Extensions;
using System;
using Xunit;

namespace DesignPatternReloadedTest.Extensions
{

    public class FuncExtensionsTest
    {

        [Fact]
        public void Test_Func_Compose()
        {
            Func<string, string> first = input => input + "1";
            Func<string, string> second = input => input + "2";
            Func<string, string> composed = first.Compose(second);

            string result = composed("0");
            Assert.Equal("021", result);
        }

        [Fact]
        public void Test_Func_AndThen()
        {
            Func<string, string> first = input => input + "1";
            Func<string, string> second = input => input + "2";
            Func<string, string> composed = first.AndThen(second);

            string result = composed("0");
            Assert.Equal("012", result);
        }

    }

}