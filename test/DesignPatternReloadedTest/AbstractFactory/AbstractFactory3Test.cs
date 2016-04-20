using System;
using Xunit;
using static DesignPatternReloaded.AbstractFactory.AbstractFactory3;

namespace DesignPatternReloadedTest.AbstractFactory
{

    public class AbstractFactory3Test
    {

        [Fact]
        public void Test_AbstractFactory3()
        {
            VehicleFactory factory = ConfigureFactory();

            IVehicle vehicle1 = factory.Create("car");
            Assert.IsType<Car>(vehicle1);
            Assert.Equal("Car ", vehicle1.ToString());
            IVehicle vehicle2 = factory.Create("moto");
            Assert.IsType<Moto>(vehicle2);
            Assert.Equal("Moto ", vehicle2.ToString());

            Assert.Throws<ArgumentException>("name", () => factory.Create("jojo"));
        }

    }

}