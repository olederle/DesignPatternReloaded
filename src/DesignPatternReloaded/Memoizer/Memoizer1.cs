using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/memoizer/memoizer1.java
// * Instead of the built-in HashMap.computeIfAbsent method we have to use an own extension method.
// * Implemented a ForEach extension method for enumerables to have something similar
//   than in Java.
// * .NET does not support anonymous classes for that reason the abstract base class was
//   renamed to MemoizerBase and a named subclass is implemented.

namespace DesignPatternReloaded.Memoizer
{

    public static class Memoizer1
    {

        public abstract class MemoizerBase<V, R>
        {
            private readonly IDictionary<V, R> dict = new Dictionary<V, R>();

            public R Memoize(V value)
            {
                return dict.ComputeIfAbsent(value, Compute);
            }

            protected abstract R Compute(V value);

        }

        public class Memoizer : MemoizerBase<int, int>
        {

            protected override int Compute(int value)
            {
                if (value < 2) return 1;
                return Memoize(value - 1) + Memoize(value - 2);
            }

        }

        public static void Main(string[] args)
        {

            Memoizer memoizer = new Memoizer();

            Enumerable.Range(0, 20).Select(memoizer.Memoize).ForEach(Console.WriteLine);
        }

    }

}