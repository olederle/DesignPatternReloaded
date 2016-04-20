using System;
using Xunit;
using static DesignPatternReloaded.Builder.Builder3;

namespace DesignPatternReloadedTest.Builder
{

    public class Builder3Test
    {

        [Fact]
        public void Test_Builder3()
        {
            CreateVehicle createVehicle = VehicleFactory.Create(register =>
            {
                register("car", Car.Create);
                register("moto", Moto.Create);
            });

            IVehicle vehicle1 = createVehicle("car");
            Assert.Equal("Car ", vehicle1.ToString());
            IVehicle vehicle2 = createVehicle("moto");
            Assert.Equal("Moto ", vehicle2.ToString());
        }

        [Fact]
        public void Test_Builder2_Failure()
        {
            CreateVehicle createVehicle = VehicleFactory.Create(register =>
            {
                register("car", Car.Create);
                register("moto", Moto.Create);
            });

            Assert.Throws<ArgumentException>(() => createVehicle("foo"));
        }

    }

}