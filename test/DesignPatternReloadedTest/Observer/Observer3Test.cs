using DesignPatternReloaded.Observer;
using System.Globalization;
using System.Threading;
using Xunit;
using static DesignPatternReloaded.Observer.Observer3;

namespace DesignPatternReloadedTest.Observer
{

    public class Observer3Test
    {

        [Fact]
        public void Test_Observer3()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string path = typeof(Observer1).Namespace + ".Data.test.csv";
            double value = new SumCSV().ParseAndSum(path);
            Assert.Equal(31.007, value, 3);
        }

    }

}