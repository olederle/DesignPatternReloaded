using DesignPatternReloaded.Builder;
using System;
using Xunit;
using static DesignPatternReloaded.Builder.Builder2;

namespace DesignPatternReloadedTest.Builder
{

    public class Builder2Test
    {

        [Fact]
        public void Test_Builder2()
        {
            Builder2.Builder builder = new Builder2.Builder();
            builder.Register("car", Car.Create);
            builder.Register("moto", Moto.Create);

            CreateVehicle createVehicle = builder.ToFactory();

            IVehicle vehicle1 = createVehicle("car");
            Assert.Equal("Car ", vehicle1.ToString());
            IVehicle vehicle2 = createVehicle("moto");
            Assert.Equal("Moto ", vehicle2.ToString());
        }

        [Fact]
        public void Test_Builder2_Failure()
        {
            Builder2.Builder builder = new Builder2.Builder();
            builder.Register("car", Car.Create);
            builder.Register("moto", Moto.Create);

            CreateVehicle createVehicle = builder.ToFactory();

            Assert.Throws<ArgumentException>(() => createVehicle("foo"));
        }

    }

}