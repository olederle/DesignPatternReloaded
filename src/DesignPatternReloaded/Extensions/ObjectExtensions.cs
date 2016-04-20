using System;

namespace DesignPatternReloaded.Extensions
{

    /// <summary>
    /// Extension methods operating on objects.
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Checks that the specified object reference is not <code>null</code>.
        /// </summary>
        /// <typeparam name="T">The type of the reference.</typeparam>
        /// <param name="obj">The object reference to check for nullity</param>
        /// <param name="message">An optional detail message for teh exception</param>
        /// <returns><em>obj</em> if not null</returns>
        /// <exception cref="NullReferenceException">Thrown in <em>obj</em> is <code>null</code></exception>
        public static T RequireNonNull<T>(this T obj, string message = null)
        {
            if (obj == null) throw new NullReferenceException(message);
            return obj;
        }

    }

}