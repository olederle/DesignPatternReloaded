using Xunit;
using static DesignPatternReloaded.Adapter.Adapter1;
using static DesignPatternReloaded.Adapter.Adapter1.Level;

namespace DesignPatternReloadedTest.Adapter
{

    public class Adapter1Test
    {

        [Fact]
        public void Test_Adapter1()
        {
            string logOutput;

            Log2 log2 = (level, msg) => logOutput = string.Format("{0} {1}", level, msg);

            logOutput = null;
            log2(Error, "abort abort !");
            Assert.Equal("Error abort abort !", logOutput);
        }

    }

}