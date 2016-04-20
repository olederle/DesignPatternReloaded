using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/memoizer/memoizer3.java
// * Instead of the built-in HashMap.computeIfAbsent method we have to use an own extension method.
// * Implemented a ForEach extension method for enumerables to have something similar
//   than in Java.
// * We use an additional CreateMemoizer method which can be reused in the unit test
//   to prevent code duplication.

namespace DesignPatternReloaded.Memoizer
{

    public static class Memoizer3
    {

        public sealed class Memoizer<V, R>
        {
            private readonly Func<V, Func<V, R>, R> function;
            private readonly IDictionary<V, R> dict = new Dictionary<V, R>();

            public Memoizer(Func<V, Func<V, R>, R> function)
            {
                this.function = function.RequireNonNull();
            }

            public R Memoize(V value)
            {
                return dict.ComputeIfAbsent(value, v => function(v, Memoize));
            }

        }

        public static Memoizer<int, int> CreateMemoizer()
        {
            return new Memoizer<int, int>((n, fib) =>
            {
                if (n < 2) return 1;
                return fib(n - 1) + fib(n - 2);
            });
        }

        public static void Main(string[] args)
        {
            Memoizer<int, int> memoizer = CreateMemoizer();

            Enumerable.Range(0, 20).Select(memoizer.Memoize).ForEach(Console.WriteLine);
        }

    }

}