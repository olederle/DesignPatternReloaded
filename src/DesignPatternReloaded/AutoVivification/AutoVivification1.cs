using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/autovivification/autovivification1.java
// * Instead of the Java functional interface we use an extension method in this example, which
//   actually seems to be a better solution than the Jave version which can not use extension
//   methods. The only drawback is that we have to use an instantiable type as value of the
//   dictionary and can not use an interface. See the second example for an alternative
//   implementation.

namespace DesignPatternReloaded.AutoVivification
{

    public static class DictionaryExtensions
    {

        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) 
            where TValue : new()
        {
            if (dict == null) throw new NullReferenceException(nameof(dict));
            TValue value;
            dict.TryGetValue(key, out value);
            if (value == null)
            {
                // The following call is not possible in Java the same way as in .NET.
                value = new TValue();
                dict[key] = value;
            }
            return value;
        }

    }

    public static class AutoVivification1
    {

        public static void Main(string[] args)
        {
            IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            dictionary.Get("foo").Add("bar");
            dictionary.Get("foo").Add("baz");

            Console.WriteLine(dictionary);
        }

    }

}