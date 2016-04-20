using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/logger/logger1.java
// * Instead of functional interfacs we have to use delegates.

namespace DesignPatternReloaded.Logger
{

    public static class Logger1
    {

        public delegate void Log(string message);

        public static void Main(string[] args)
        {
            Log log = msg => Console.WriteLine(msg);

            log("hello");
        }

    }

}