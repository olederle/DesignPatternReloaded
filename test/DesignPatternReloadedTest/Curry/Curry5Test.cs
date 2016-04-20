using System;
using Xunit;
using static DesignPatternReloaded.Curry.Curry5;

namespace DesignPatternReloadedTest.Curry
{

    public class Curry5Test
    {

        private static Func<string, Func<string, IVehicle>> createVehicle = CreateVehicleFactoryMethod();

        [Fact]
        public void Test_Curry5_Car_ExistingColor()
        {
            IVehicle vehicle = createVehicle("car")("violet");
            Assert.Equal("Car Magenta", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry5_Moto_ExistingColor()
        {
            IVehicle vehicle = createVehicle("moto")("blue");
            Assert.Equal("Moto Blue", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry5_Car_NonExistingColor()
        {
            IVehicle vehicle = createVehicle("car")("yellow");
            Assert.Equal("Car Black", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry5_NonExistingMoto()
        {
            Assert.Throws<ArgumentException>(() => createVehicle("train")("violet"));
        }

    }

}