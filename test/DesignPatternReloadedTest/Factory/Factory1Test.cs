using System.Collections.Generic;
using Xunit;
using static DesignPatternReloaded.Factory.Factory1;

namespace DesignPatternReloadedTest.Factory
{

    public class Factory1Test
    {

        [Fact]
        public void Test_Factory1()
        {
            CreateVehicle redCarFactory = () => new Car(Color.Red);
            CreateVehicle blueMotoFactory = () => new Moto(Color.Blue);

            IList<IVehicle> redCars = Create5(redCarFactory);

            Assert.Equal(5, redCars.Count);
            Assert.Equal("Car Red", redCars[0].ToString());
            Assert.Equal("Car Red", redCars[1].ToString());
            Assert.Equal("Car Red", redCars[2].ToString());
            Assert.Equal("Car Red", redCars[3].ToString());
            Assert.Equal("Car Red", redCars[4].ToString());

            IList<IVehicle> blueMotos = Create5(blueMotoFactory);

            Assert.Equal(5, blueMotos.Count);
            Assert.Equal("Moto Blue", blueMotos[0].ToString());
            Assert.Equal("Moto Blue", blueMotos[1].ToString());
            Assert.Equal("Moto Blue", blueMotos[2].ToString());
            Assert.Equal("Moto Blue", blueMotos[3].ToString());
            Assert.Equal("Moto Blue", blueMotos[4].ToString());
        }

    }

}