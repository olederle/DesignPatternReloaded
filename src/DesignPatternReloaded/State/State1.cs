using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/state/state1.java
// * Interfaces can not define nested enumerations in .NET
// * Instead of the Consumer functional Java interface we have use the Action delegate.
// * Instead of an anonymous class we use a lamda expression.
// * Logger implementations moved to the Loggers class.

namespace DesignPatternReloaded.State
{

    public static class State1
    {

        enum Level { Error, Warning }

        public interface ILogger
        {
            
            void Error(string message);

            void Warning(string message);

            ILogger Quiet();
            ILogger Chatty();

        }

        public static class Loggers
        {
            public static ILogger Logger(Action<string> printer)
            {
                return new ChattyLogger(printer);
            }

            private class ChattyLogger : ILogger
            {
                private readonly Action<string> printer;

                internal ChattyLogger(Action<string> printer)
                {
                    this.printer = printer;
                }

                public ILogger Chatty()
                {
                    return this;
                }

                public void Error(string message)
                {
                    printer(message);
                }

                public ILogger Quiet()
                {
                    return new QuietLogger(printer);
                }

                public void Warning(string message)
                {
                    printer(message);
                }
            }

            private class QuietLogger : ILogger
            {
                private readonly Action<string> printer;

                internal QuietLogger(Action<string> printer)
                {
                    this.printer = printer;
                }

                public ILogger Chatty()
                {
                    return new ChattyLogger(printer);
                }

                public void Error(string message)
                {
                    printer(message);
                }

                public ILogger Quiet()
                {
                    return this;
                }

                public void Warning(string message)
                {
                    // empty
                }
            }

        }
        
        public static void Main(string[] args)
        {
            ILogger logger = Loggers.Logger(msg => Console.WriteLine(msg));

            logger.Error("ERROR");
            logger.Warning("WARNING");

            ILogger quiet = logger.Quiet();
            quiet.Error("ERROR");
            quiet.Warning("WARNING");

            ILogger logger2 = quiet.Chatty();
            logger2.Error("ERROR");
            logger2.Warning("WARNING");
        }

    }

}