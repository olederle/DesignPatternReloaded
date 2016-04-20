using System;
using DesignPatternReloaded.Extensions;
using static DesignPatternReloaded.Logger.Logger5;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger5.java
// * Instead of functional interfacs we have to use delegates.
// * Instead of default methods of an interface we have to use extension methods.

namespace DesignPatternReloaded.Logger
{

    public static class Log5Extensions
    {
        public static Log Filter(this Log log, Filter filter)
        {
            filter.RequireNonNull();
            return message =>
            {
                if (filter(message))
                    log(message);
            };
        }
    }

    public static class Logger5
    {

        public delegate void Log(string message);

        public delegate bool Filter(string message);

        public static void Main(string[] args)
        {
            Log log = msg => Console.WriteLine(msg);
            log("hello");

            Filter filter = msg => msg.StartsWith("hell");
            Log filterLog = log.Filter(filter);
            filterLog("hello");
            filterLog("ok");
        }

    }

}