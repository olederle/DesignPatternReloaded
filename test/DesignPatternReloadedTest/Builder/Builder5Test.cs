using System;
using Xunit;
using static DesignPatternReloaded.Builder.Builder5;

namespace DesignPatternReloadedTest.Builder
{

    public class Builder5Test
    {

        [Fact]
        public void Test_Builder5()
        {
            Func<string, Func<IVehicle>> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); });

            IVehicle vehicle1 = factory("car")();
            Assert.Equal("Car ", vehicle1.ToString());
            IVehicle vehicle2 = factory("moto")();
            Assert.Equal("Moto ", vehicle2.ToString());
        }

        [Fact]
        public void Test_Builder2_Failure()
        {
            Func<string, Func<IVehicle>> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); });

            Assert.Throws<ArgumentException>(() => factory("foo")());
        }

    }

}