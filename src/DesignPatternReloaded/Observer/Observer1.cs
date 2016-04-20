using DesignPatternReloaded.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/observer/observer1.java
// * We use an extension method to get all lines of a stream as en enumerable.

namespace DesignPatternReloaded.Observer
{

    public static class Observer1
    {

        public class SumCSV
        {

            public static double ParseAndSum(string name)
            {
                using (StreamReader reader = new StreamReader(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(name)))
                {
                    return reader.Lines()
                        .SelectMany(line => line.Split(','))
                        .Select(token => double.Parse(token))
                        .Sum();
                }
            }

        }

        public static void Main(string[] args)
        {
            // We have to set the culture explicitely, otherwise double.Parse method above would
            // depend on the current culture of the operating system.
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string path = typeof(Observer1).Namespace + ".Data.test.csv";
            double value = SumCSV.ParseAndSum(path);
            Console.WriteLine(value);
        }

    }

}