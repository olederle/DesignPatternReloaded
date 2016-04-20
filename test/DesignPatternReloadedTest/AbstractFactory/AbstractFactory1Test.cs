using Xunit;
using static DesignPatternReloaded.AbstractFactory.AbstractFactory1;

namespace DesignPatternReloadedTest.AbstractFactory
{

    public class AbstractFactory1Test
    {

        [Fact]
        public void Test_AbstractFactory1()
        {
            Vehicle vehicle1 = Vehicle.Create("car");
            Assert.IsType<Car>(vehicle1);
            Assert.Equal("Car ", vehicle1.ToString());
            Vehicle vehicle2 = Vehicle.Create("moto");
            Assert.IsType<Moto>(vehicle2);
            Assert.Equal("Moto ", vehicle2.ToString());
        }

    }

}