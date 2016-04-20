using Xunit;
using static DesignPatternReloaded.Visitor.Visitor0;

namespace DesignPatternReloadedTest.Visitor
{

    public class Visitor0Test
    {

        [Fact]
        public void Test_Visitor0()
        {
            Visitor<string> visitor = new DefaultVisitor();

            IVehicle vehicle1 = new Car();
            string text1 = vehicle1.Accept(visitor);
            Assert.Equal("car", text1);

            IVehicle vehicle2 = new Moto();
            string text2 = vehicle2.Accept(visitor);
            Assert.Equal("moto", text2);
        }

    }

}