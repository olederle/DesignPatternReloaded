using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/observer/observer3.java
// * We use an extension method to get all lines of a stream as en enumerable.
// * Instead of a new delegate which represents the Java functional Observer interface we
//   use the built-in Action delegae to reuse the existing ForEach extension method. Java
//   accepts functions if they have the appropriate signature, whereas .NET is much more 
//   restrictive with delegates.

namespace DesignPatternReloaded.Observer
{

    public static class Observer3
    {

        public class CSVParser
        {

            public static void Parse(string name, Action<double> observer)
            {
                using (StreamReader reader = new StreamReader(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(name)))
                {
                    reader.Lines()
                        // Unfortunatley we need an explicit cast and therefore it is not as
                        // concise as in Java.
                        .SelectMany((Func<string, IEnumerable<string>>)new Regex(",").Split)
                        .Select(double.Parse)
                        .ForEach(observer);
                }
            }

        }

        public class SumCSV
        {

            private double sum;

            public double ParseAndSum(string name)
            {
                CSVParser.Parse(name, value => sum += value);
                return sum;
            }

        }

        public static void Main(string[] args)
        {
            // We have to set the culture explicitely, otherwise double.Parse method above would
            // depend on the current culture of the operating system.
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string path = typeof(Observer1).Namespace + ".Data.test.csv";
            double value = new SumCSV().ParseAndSum(path);
            Console.WriteLine(value);
        }

    }

}