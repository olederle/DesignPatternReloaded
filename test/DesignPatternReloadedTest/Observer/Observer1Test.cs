using DesignPatternReloaded.Observer;
using System.Globalization;
using System.Threading;
using Xunit;
using static DesignPatternReloaded.Observer.Observer1;

namespace DesignPatternReloadedTest.Observer
{

    public class Observer1Test
    {

        [Fact]
        public void Test_Observer1()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string path = typeof(Observer1).Namespace + ".Data.test.csv";
            double value = SumCSV.ParseAndSum(path);
            Assert.Equal(31.007, value, 3);
        }

    }

}