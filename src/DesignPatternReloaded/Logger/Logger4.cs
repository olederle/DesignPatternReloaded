using System;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger4.java
// * Instead of functional interfacs we have to use delegates.

namespace DesignPatternReloaded.Logger
{

    public static class Logger4
    {

        public delegate void Log(string message);

        public delegate bool Filter(string message);

        public static class Loggers
        {
            public static Log FilterLogger(Log log, Filter filter)
            {
                log.RequireNonNull();
                filter.RequireNonNull();
                return message => 
                {
                    if (filter(message))
                        log(message);
                };
            }
        }

        public static void Main(string[] args)
        {
            Log log = msg => Console.WriteLine(msg);
            log("hello");

            Filter filter = msg => msg.StartsWith("hell");
            Log filterLog = Loggers.FilterLogger(log, filter);
            filterLog("hello");
            filterLog("ok");
        }

    }

}