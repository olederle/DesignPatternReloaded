using Xunit;
using static DesignPatternReloaded.AbstractFactory.AbstractFactory4;

namespace DesignPatternReloadedTest.AbstractFactory
{

    public class AbstractFactory4Test
    {

        [Fact]
        public void Test_AbstractFactory4()
        {
            VehicleFactory factory = ConfigureFactory();

            IVehicle vehicle1 = factory.Create("car");
            IVehicle vehicle2 = factory.Create("car");
            Assert.NotSame(vehicle1, vehicle2);

            IVehicle vehicle3 = factory.Create("moto");
            IVehicle vehicle4 = factory.Create("moto");
            Assert.Same(vehicle3, vehicle4);
        }

    }

}