using System;
using static DesignPatternReloaded.Adapter.Adapter2;
using static DesignPatternReloaded.Adapter.Adapter2.Level;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/adapter/adapter2.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET naming convention for enum values.
// * Instead of default methods of an interface we have to use extension methods.

namespace DesignPatternReloaded.Adapter
{

    public static class Adapter2Extensions
    {
        public static Log Level(this Log2 log2, Level level)
        {
            return msg => log2(level, msg);
        }
    }

    public static class Adapter2
    {

        public delegate void Log(string message);

        public enum Level { Warning, Error }

        public delegate void Log2(Level level, string message);

        public static void Main(string[] args)
        {
            Log2 log2 = (level, msg) => Console.WriteLine(string.Format("{0} {1}", level, msg));
            log2(Error, "abort abort !");

            log2.Level(Error)("abort abort !");
        }

    }

}