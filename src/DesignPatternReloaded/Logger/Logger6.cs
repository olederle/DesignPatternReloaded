using DesignPatternReloaded.Extensions;
using System;
using static DesignPatternReloaded.Logger.Logger6;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger6.java
// * Instead of functional interfacs we have to use delegates.
// * Instead of default methods of an interface we have to use extension methods.
// * Instead of the Predicate functional Java interface we have to use the Predicate delegate.

namespace DesignPatternReloaded.Logger
{

    public static class Log6Extensions
    {
        public static Log Filter(this Log log, Predicate<string> filter)
        {
            filter.RequireNonNull();
            return message =>
            {
                if (filter(message))
                    log(message);
            };
        }
    }

    public static class Logger6
    {

        public delegate void Log(string message);

        public static void Main(string[] args)
        {
            Log log = msg => Console.WriteLine(msg);
            log("hello");

            Predicate<string> filter = msg => msg.StartsWith("hell");
            Log filterLog = log.Filter(filter);
            filterLog("hello");
            filterLog("ok");
        }

    }

}