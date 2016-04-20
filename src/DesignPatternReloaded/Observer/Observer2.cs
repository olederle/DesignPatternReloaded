using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/observer/observer2.java
// * We use an extension method to get all lines of a stream as en enumerable.

namespace DesignPatternReloaded.Observer
{

    public static class Observer2
    {

        public class SumCSV
        {

            public static double ParseAndSum(string name)
            {

                using (StreamReader reader = new StreamReader(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(name)))
                {
                    return reader.Lines()
                        // Unfortunatley we need an explicit cast and therefore it is not as
                        // concise as in Java.
                        .SelectMany((Func<string, IEnumerable<string>>)new Regex(",").Split)
                        .Select(double.Parse)
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