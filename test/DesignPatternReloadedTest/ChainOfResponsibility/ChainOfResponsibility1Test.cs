using System.Linq;
using Xunit;
using static DesignPatternReloaded.ChainOfResponsibility.ChainOfResponsibility1;

namespace DesignPatternReloadedTest.Builder
{

    public class ChainOfResponsibility1Test
    {

        [Fact]
        public void Test_ChainOfResponsibility1()
        {
            Expr expr = Expr.Parse("+ 2 * a 3".Split(' ').AsEnumerable().GetEnumerator());
            Assert.Equal("(2 + (a * 3))", expr.ToString());
        }

    }

}