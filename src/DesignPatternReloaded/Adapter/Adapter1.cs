using System;
using static DesignPatternReloaded.Adapter.Adapter1.Level;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/adapter/adapter1.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET naming convention for enum values.

namespace DesignPatternReloaded.Adapter
{

    public static class Adapter1
    {

        public delegate void Log(string message);

        public enum Level { Warning, Error }

        public delegate void Log2(Level level, string message);

        public static void Main(string[] args)
        {
            Log2 log2 = (level, msg) => Console.WriteLine(string.Format("{0} {1}", level, msg));
            log2(Error, "abort abort !");

#pragma warning disable CS0219
            Log log = null; // how to use Log2 here?
#pragma warning restore CS0219
        }

    }

}