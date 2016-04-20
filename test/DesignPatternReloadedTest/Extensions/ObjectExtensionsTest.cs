using DesignPatternReloaded.Extensions;
using System;
using Xunit;

namespace DesignPatternReloadedTest.Extensions
{

    public class ObjectExtensionsTest
    {

        [Fact]
        public void Test_NonNull()
        {
            object obj = new object();
            object obj1 = obj.RequireNonNull();

            Assert.NotNull(obj1);
            Assert.Same(obj, obj1);
        }

        [Fact]
        public void Test_Null_WithoutMessage()
        {
            object obj = null;

            NullReferenceException ex = Assert.Throws<NullReferenceException>(
                () => obj.RequireNonNull());
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void Test_Null_WithMessage()
        {
            object obj = null;

            NullReferenceException ex = Assert.Throws<NullReferenceException>(
                () => obj.RequireNonNull("obj is null"));
            Assert.Equal("obj is null", ex.Message);
        }


    }

}