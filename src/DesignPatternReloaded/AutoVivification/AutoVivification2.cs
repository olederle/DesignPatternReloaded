using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/autovivification/autovivification1.java
// * The first version of this example has the drawback that the type of the values of
//   the dictionary must be an instantiable class. This version is a little bit more like
//   the original Java implementation but because .NET does not support functional
//   interface with default methods we have to use a static class and a delegate to
//   implement something "similar".
// * Instead of the built-in HashMap.computeIfAbsent method we have to use an own extension method.

namespace DesignPatternReloaded.AutoVivification
{

    public static class AutoVivification2
    {

        public static class Dict
        {

            public delegate V Get<K, V>(K key);

            public static Get<K, V> AsGet<K, V>(IDictionary<K, V> dictionary, Func<V> factory)
            {
                return key => dictionary.ComputeIfAbsent(key, k => factory());
            }

        }

        public static void Main(string[] args)
        {
            IDictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
            Dict.Get<string, IList<string>> dict = Dict.AsGet(dictionary, () => new List<string>());

            dict("foo").Add("bar");
            dict("foo").Add("baz");

            Console.WriteLine(dictionary);
        }

    }

}