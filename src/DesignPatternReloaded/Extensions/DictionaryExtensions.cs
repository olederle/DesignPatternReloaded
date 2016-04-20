using DesignPatternReloaded.Util;
using System;
using System.Collections.Generic;

namespace DesignPatternReloaded.Extensions
{

    /// <summary>
    /// Extension methods operating on an <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    public static class DictionaryExtensions
    {

        /// <summary>
        /// Returns the value with the specified key as Optional from the dictionary. If
        /// the key does not exist, an empty Optional is returned.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <param name="dict">The dictionary instance to extend.</param>
        /// <param name="key">The key.</param>
        /// <returns>The value as Optional.</returns>
        public static Optional<TValue> Get<TKey, TValue>(this IDictionary<TKey, TValue> dict,
            TKey key)
        {
            return dict.ContainsKey(key) 
                ? Optional.OfNullable(dict[key]) 
                : Optional.Empty<TValue>();
        }

        /// <summary>
        /// Returns the value with the specified key from the dictionary or the default value
        /// if the key does not exist in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <param name="dict">The dictionary instance to extend.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value used if the key does not exist.</param>
        /// <returns>
        /// The value of the dictionary with the specified key or the default value.
        /// </returns>
        /// <seealso cref="ComputeIfAbsent{TKey, TValue}(IDictionary{TKey, TValue}, TKey, Func{TKey, TValue})"/>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict,
            TKey key,
            TValue defaultValue)
        {
            if (dict == null) return defaultValue;
            TValue value;
            return dict.TryGetValue(key, out value) ? value : defaultValue;
        }

        /// <summary>
        /// Returns the value with the specified key from the dictionary or the value provided
        /// by the <em>ifAbsent</em> function, if the key does not exist in the dictionary.
        /// The computed value is entered to the dictionary unless it is null.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <param name="dict">The dictionary instance to extend.</param>
        /// <param name="key">The key.</param>
        /// <param name="ifAbsent">
        /// A function used to retrieve the value for the requested key, if the key does not
        /// exist in the dictionary.
        /// </param>
        /// <returns>
        /// The value of the dictionary with the sepcified key or the value provided by
        /// the given <em>ifAbsent</em> function.
        /// </returns>
        /// <seealso cref="GetOrDefault{TKey, TValue}(IDictionary{TKey, TValue}, TKey, TValue)"/>
        public static TValue ComputeIfAbsent<TKey, TValue>(this IDictionary<TKey, TValue> dict,
            TKey key,
            Func<TKey, TValue> ifAbsent)
        {
            if (dict == null) return ifAbsent(key);
            TValue value;
            if (dict.TryGetValue(key, out value)) return value;
            value = ifAbsent(key);
            if (value != null)
            {
                dict[key] = value;
            }
            return value;
            
        }

    }

}