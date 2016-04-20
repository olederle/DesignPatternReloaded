using System;
using Xunit;
using static DesignPatternReloaded.Curry.Curry1;

namespace DesignPatternReloadedTest.Curry
{

    public class Curry1Test
    {

        [Fact]
        public void Test_Curry1_Car_ExistingColor()
        {
            IVehicle vehicle = CreateVehicle("car", "violet");
            Assert.Equal("Car Magenta", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry1_Moto_ExistingColor()
        {
            IVehicle vehicle = CreateVehicle("moto", "blue");
            Assert.Equal("Moto Blue", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry1_Car_NonExistingColor()
        {
            IVehicle vehicle = CreateVehicle("car", "yellow");
            Assert.Equal("Car Black", vehicle.ToString());
        }

        [Fact]
        public void Test_Curry1_NonExistingMoto()
        {
            Assert.Throws<ArgumentException>(() => CreateVehicle("train", "violet"));
        }

    }

}