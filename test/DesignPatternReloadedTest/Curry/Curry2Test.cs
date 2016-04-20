using System;
using Xunit;
using static DesignPatternReloaded.Curry.Curry2;

namespace DesignPatternReloadedTest.Curry
{

    public class Curry2Test
    {

        private static Func<string, string, IVehicle> createVehicle = CreateVehicleFactoryMethod();

        [Fact]
        public void Test_Curry2_Car_ExistingColor()
        {
            IVehicle vehicle = createVehicle("car", "violet");
            Assert.Equal("Car Magenta", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry2_Moto_ExistingColor()
        {
            IVehicle vehicle = createVehicle("moto", "blue");
            Assert.Equal("Moto Blue", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry2_Car_NonExistingColor()
        {
            IVehicle vehicle = createVehicle("car", "yellow");
            Assert.Equal("Car Black", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry2_NonExistingMoto()
        {
            Assert.Throws<ArgumentException>(() => createVehicle("train", "violet"));
        }

    }

}