using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/memoizer/memoizer5.java
// * Instead of the built-in HashMap.computeIfAbsent method we have to use an own extension method.
// * Implemented a ForEach extension method for enumerables to have something similar
//   than in Java.
// * We use an additional CreateFibo method which can be reused in the unit test
//   to prevent code duplication.

namespace DesignPatternReloaded.Memoizer
{

    public static class Memoizer5
    {

        private static Func<V, R> Memoize<V, R>(Func<V, Func<V, R>, R> func)
        {
            IDictionary<V, R> dict = new Dictionary<V, R>();
            Func<V, R> memoizer = null; // prevent compile error that memoizer is not initialized
            return memoizer = value => dict.ComputeIfAbsent(value, v => func(v, memoizer));
        }

        public static Func<int, int> CreateFibo()
        {
            return Memoize<int, int>((n, fib) =>
            {
                if (n < 2) return 1;
                return fib(n - 1) + fib(n - 2);
            });
        }

        public static void Main(string[] args)
        {
            Func<int, int> fibo = CreateFibo();

            Enumerable.Range(0, 20).Select(fibo).ForEach(Console.WriteLine);
        }

    }

}