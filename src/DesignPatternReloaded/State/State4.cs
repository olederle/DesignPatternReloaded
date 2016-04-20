using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/state/state4.java
// * Interfaces can not define nested enumerations in .NET
// * Instead of the Consumer functional Java interface we have use the Action delegate.
// * .NET does not provide an identity function, so we use it => it.
// * We have renamed the static logger method to Create, because otherwise the name would be
//   the same as the name of the class which is not valid.

namespace DesignPatternReloaded.State
{

    public static class State4
    {

        enum Level { Error, Warning }

        public sealed class Logger
        {

            private readonly Action<string> error;
            private readonly Action<string> warning;
            private readonly Logger quiet;
            private readonly Logger chatty;

            private Logger(Action<string> error,
                Action<string> warning,
                Func<Logger, Logger> quietFactory,
                Func<Logger, Logger> chattyFactory)
            {
                this.error = error;
                this.warning = warning;
                quiet = quietFactory(this);
                chatty = chattyFactory(this);
            }

            public void Error(string message)
            {
                error(message);
            }

            public void Warning(string message)
            {
                warning(message);
            }

            public Logger Quiet()
            {
                return quiet;
            }

            public Logger Chatty()
            {
                return chatty;
            }

            public static Logger Create(Action<string> consumer)
            {
                return new Logger(consumer,
                    consumer,
                    normal => new Logger(consumer, msg => { /* empty */}, it => it, it => normal),
                    it => it);
            }

        }

        public static void Main(string[] args)
        {
            Logger logger = Logger.Create(Console.WriteLine);
            logger.Error("ERROR");
            logger.Warning("WARNING");

            Logger quiet = logger.Quiet();
            quiet.Error("ERROR");
            quiet.Warning("WARNING");

            Logger logger2 = quiet.Chatty();
            logger2.Error("ERROR");
            logger2.Warning("WARNING");
        }

    }

}