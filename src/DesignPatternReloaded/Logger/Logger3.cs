using System;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger3.java
// It's difficult to implement this example in the same spirit than the original Java example
// because Java is using functional interfaces and .NET is using delegates. Unfortunately,
// a delegate is not an interface so we can not implement it as smart as in Java.
//
// So to port the example to .NET we could either:
// 1. Do not use delegates at all but only interfaces and inheritance
// 2. Create for each "functional interface" a default implementation which is just using a 
//    delegate as target (the implementation uses this solution)
// 3. Use some sort of runtime proxy generation which automatically creates the class of soluton 2

namespace DesignPatternReloaded.Logger
{

    public static class Logger3
    {

        public interface ILogger
        {
            void Log(string message);
        }

        public interface IFilter
        {
            bool Accept(string message);
        }

        // This class is required in .NET because a delegate is not an interface (see above).
        public sealed class Logger : ILogger
        {

            private readonly Action<string> log;

            public Logger(Action<string> log)
            {
                this.log = log.RequireNonNull();
            }

            public void Log(string message)
            {
                log(message);
            }

        }

        // This class is required in .NET because a delegate is not an interface (see above).
        public sealed class Filter : IFilter
        {
            private readonly Predicate<string> filter;

            public Filter(Predicate<string> filter)
            {
                this.filter = filter.RequireNonNull();
            }

            public bool Accept(string message)
            {
                return filter(message);
            }
        }

        public sealed class FilterLogger : ILogger
        {

            private readonly ILogger logger;
            private readonly IFilter filter;

            public FilterLogger(ILogger logger, IFilter filter)
            {
                this.logger = logger.RequireNonNull();
                this.filter = filter.RequireNonNull();
            }

            public void Log(string message)
            {
                if (filter.Accept(message))
                {
                    logger.Log(message);
                }
            }
        }

        public static void Main(string[] args)
        {
            Logger logger = new Logger(msg => Console.WriteLine(msg));
            logger.Log("hello");

            FilterLogger filterLogger = new FilterLogger(logger, new Filter(s => s.StartsWith("hell")));
            filterLogger.Log("hello");
            filterLogger.Log("ok");
        }

    }

}