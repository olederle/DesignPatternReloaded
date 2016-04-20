using DesignPatternReloaded.Adapter;
using Xunit;
using static DesignPatternReloaded.Adapter.Adapter2;
using static DesignPatternReloaded.Adapter.Adapter2.Level;

namespace DesignPatternReloadedTest.Adapter
{

    public class Adapter2Test
    {

        [Fact]
        public void Test_Adapter2()
        {
            string logOutput;

            Log2 log2 = (level, msg) => logOutput = string.Format("{0} {1}", level, msg);

            logOutput = null;
            log2(Error, "abort abort !");
            Assert.Equal("Error abort abort !", logOutput);

            logOutput = null;
            log2.Level(Error)("abort abort !");
            Assert.Equal("Error abort abort !", logOutput);
        }

    }

}