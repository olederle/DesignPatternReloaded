using System;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger2.java
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

    public static class Logger2
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

        public abstract class FilterLogger : ILogger, IFilter
        {

            private readonly ILogger logger;

            public abstract bool Accept(string message);

            public FilterLogger(ILogger logger)
            {
                this.logger = logger.RequireNonNull();
            }

            public void Log(string message)
            {
                if (Accept(message))
                {
                    logger.Log(message);
                }
            }
        }

        // .NET does not support anonymous classes.
        public sealed class ConcreteFilterLogger : FilterLogger
        {

            public ConcreteFilterLogger(ILogger logger) : base(logger) { }

            public override bool Accept(string message)
            {
                return message.StartsWith("hell");
            }
        }

        public static void Main(string[] args)
        {
            Logger logger = new Logger(msg => Console.WriteLine(msg));
            logger.Log("hello");

            FilterLogger filterLogger = new ConcreteFilterLogger(logger);
            filterLogger.Log("hello");
            filterLogger.Log("ok");
        }

    }

}