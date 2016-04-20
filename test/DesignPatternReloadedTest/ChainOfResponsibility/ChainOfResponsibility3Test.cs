using System.Linq;
using Xunit;
using static DesignPatternReloaded.ChainOfResponsibility.ChainOfResponsibility3;

namespace DesignPatternReloadedTest.Builder
{

    public class ChainOfResponsibility3Test
    {

        [Fact]
        public void Test_ChainOfResponsibility3()
        {
            Expr expr = Parse("+ 2 * a 3".Split(' ').AsEnumerable().GetEnumerator());
            Assert.Equal("(2 + (a * 3))", expr.ToString());
        }

    }

}