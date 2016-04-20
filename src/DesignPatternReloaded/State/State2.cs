using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/state/state2.java
// * Same as for State1.
// * In C# there is no implicit reference to the instance of the enclosing class for that
//   reason QuietLogger contains an explicit reference to ChattyLogger. Therefore it isn't
//   necessary to implement QuietLogger as nested class of ChattyLogger.

namespace DesignPatternReloaded.State
{

    public static class State2
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

                public virtual ILogger Chatty()
                {
                    return this;
                }

                public void Error(string message)
                {
                    printer(message);
                }

                public virtual ILogger Quiet()
                {
                    return new QuietLogger(this, printer);
                }

                public virtual void Warning(string message)
                {
                    printer(message);
                }

            }

            private class QuietLogger : ChattyLogger
            {

                private readonly ChattyLogger chattyLogger;

                internal QuietLogger(ChattyLogger chattyLogger, Action<string> printer) 
                    : base(printer)
                {
                    this.chattyLogger = chattyLogger;
                }

                public override ILogger Chatty()
                {
                    return chattyLogger;
                }

                public override ILogger Quiet()
                {
                    return this;
                }

                public override void Warning(string message)
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