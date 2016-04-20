using System.Collections.Generic;
using Xunit;
using static DesignPatternReloaded.Factory.Factory3;

namespace DesignPatternReloadedTest.Factory
{

    public class Factory3Test
    {

        [Fact]
        public void Test_Factory3()
        {
            IList<IVehicle> redCars = Create5(Partial(Car.Create, Color.Red));

            Assert.Equal(5, redCars.Count);
            Assert.Equal("Car Red", redCars[0].ToString());
            Assert.Equal("Car Red", redCars[1].ToString());
            Assert.Equal("Car Red", redCars[2].ToString());
            Assert.Equal("Car Red", redCars[3].ToString());
            Assert.Equal("Car Red", redCars[4].ToString());

            IList<IVehicle> blueMotos = Create5(Partial(Moto.Create, Color.Blue));

            Assert.Equal(5, blueMotos.Count);
            Assert.Equal("Moto Blue", blueMotos[0].ToString());
            Assert.Equal("Moto Blue", blueMotos[1].ToString());
            Assert.Equal("Moto Blue", blueMotos[2].ToString());
            Assert.Equal("Moto Blue", blueMotos[3].ToString());
            Assert.Equal("Moto Blue", blueMotos[4].ToString());
        }

    }

}