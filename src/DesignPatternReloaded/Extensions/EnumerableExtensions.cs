using DesignPatternReloaded.Util;
using System;
using System.Collections.Generic;

namespace DesignPatternReloaded.Extensions
{

    /// <summary>
    /// Extension methods for enumerables.
    /// </summary>
    public static class EnumerableExtensions
    {

        /// <summary>
        /// Returns the first element of the enumerable as Optional. This might be an
        /// empty Optional if the enumerable is empty.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <param name="enumerable">The instance to extend.</param>
        /// <returns>The first element of the enumerable as Optional.</returns>
        public static Optional<T> FirstAsOptional<T>(this IEnumerable<T> enumerable)
        {
            using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
            {
                return enumerator.MoveNext()
                    ? Optional.OfNullable(enumerator.Current)
                    : Optional.Empty<T>();
            }
        }

        /// <summary>
        /// Performs an action fo reach element of the enumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <param name="enumerable">The instance to extend.</param>
        /// <param name="action">A non-interfering action to perform on the elements.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }

    }

}