using DesignPatternReloaded.Extensions;
using System;
using Xunit;
using static DesignPatternReloaded.Builder.Builder6;

namespace DesignPatternReloadedTest.Builder
{

    public class Builder6Test
    {

        [Fact]
        public void Test_Builder6()
        {
            Func<string, IVehicle> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); })
            .AndThen(f => f());

            IVehicle vehicle1 = factory("car");
            Assert.Equal("Car ", vehicle1.ToString());
            IVehicle vehicle2 = factory("moto");
            Assert.Equal("Moto ", vehicle2.ToString());
        }

        [Fact]
        public void Test_Builder2_Failure()
        {
            Func<string, IVehicle> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); })
            .AndThen(f => f());

            Assert.Throws<ArgumentException>(() => factory("foo"));
        }

    }

}