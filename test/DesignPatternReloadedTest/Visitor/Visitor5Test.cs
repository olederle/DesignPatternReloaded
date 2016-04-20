using Xunit;
using static DesignPatternReloaded.Visitor.Visitor5;

namespace DesignPatternReloadedTest.Visitor
{

    public class Visitor5Test
    {

        [Fact]
        public void Test_Visitor5()
        {
            Visitor<string> visitor = ConfigureVisitor();

            IVehicle vehicle1 = new Car();
            string text1 = visitor.Call(vehicle1);
            Assert.Equal("car", text1);

            IVehicle vehicle2 = new Moto();
            string text2 = visitor.Call(vehicle2);
            Assert.Equal("moto", text2);
        }

    }

}