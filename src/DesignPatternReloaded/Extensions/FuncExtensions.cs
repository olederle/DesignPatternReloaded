using System;

namespace DesignPatternReloaded.Extensions
{

    /// <summary>
    /// Extension methods for the Func delegate to mimic the default methods of the
    /// Function functional Java interface.
    /// </summary>
    public static class FuncExtensions
    {

        /// <summary>
        /// <para>
        /// Returns a composed function that will first apply the <em>before</em> function to
        /// the input, and then applies this (<em>func</em>) to the result.
        /// </para>
        /// <para>
        /// If the evaluation of either of the two functions throws an exception, it is relayed to
        /// the caller of the composed function.
        /// </para>
        /// </summary>
        /// <typeparam name="V">
        /// The type of input to the <em>before</em> function, and to the composed function.
        /// </typeparam>
        /// <typeparam name="T">
        /// The type of input to this (<em>func</em>) function, and the result of the 
        /// <em>before</em> function.
        /// </typeparam>
        /// <typeparam name="R">
        /// The type of the result of the this (<em>funct</em>) function.
        /// </typeparam>
        /// <param name="func">The function delegate to extend.</param>
        /// <param name="before">
        /// The function to apply before this (<em>func</em>) function is applied.
        /// </param>
        /// <returns>
        /// A composed function that first will apply the <em>before</em> function and then
        /// will apply this (<em>func</em>) function.
        /// </returns>
        /// <seealso cref="AndThen{T, V, R}(Func{T, R}, Func{R, V})"/>
        public static Func<V, R> Compose<V, T, R>(this Func<T, R> func, Func<V, T> before)
        {
            return obj => func(before(obj));
        }

        /// <summary>
        /// <para>
        /// Returns a composed function that will first apply this (<em>func</em>) function to
        /// the input, and then will apply the <em>after</em> function to the result. 
        /// </para>
        /// <para>
        /// If the evaluation of either of the functions throw an exception, it is relayed to the 
        /// caller of the composed function.
        /// </para>
        /// </summary>
        /// <typeparam name="T">
        /// The type of the input to this (<em>func</em>) function, and to the composed function.
        /// </typeparam>
        /// <typeparam name="V">
        /// The type of the output to the <em>after</em> function, and of the composed function.
        /// </typeparam>
        /// <typeparam name="R">
        /// The type of the result of this (<em>func</em>) function, and the input of the
        /// <em>after</em> function.
        /// </typeparam>
        /// <param name="func">The function delegate to extend.</param>
        /// <param name="after">
        /// The function to apply after this (<em>func</em>) function is applied.
        /// </param>
        /// <returns>
        /// A composed funtion that will first apply this (<em>func</em>) function and then
        /// will apply the after function.
        /// </returns>
        /// <seealso cref="Compose{V, T, R}(Func{T, R}, Func{V, T})"/>
        public static Func<T, V> AndThen<T, V, R>(this Func<T, R> func, Func<R, V> after)
        {
            return obj => after(func(obj));
        }

        /// <summary>
        /// <para>
        /// Returns a composed function that will first apply this (<em>func</em>) function to
        /// the input, and then will apply the <em>after</em> predicate to the result. 
        /// </para>
        /// <para>
        /// If the evaluation of either of the functions throw an exception, it is relayed to the 
        /// caller of the composed function.
        /// </para>
        /// </summary>
        /// <remarks>
        /// This method is requied, because a Predicate is not a Func.
        /// </remarks>
        /// <typeparam name="T">
        /// The type of the input to this (<em>func</em>) function, and to the composed function.
        /// </typeparam>
        /// <typeparam name="R">
        /// The type of the result of this (<em>func</em>) function, and the input of the
        /// <em>after</em> function.
        /// </typeparam>
        /// <param name="func">The function delegate to extend.</param>
        /// <param name="after">
        /// The predicate to apply after this (<em>func</em>) function is applied.
        /// </param>
        /// <returns>
        /// <returns>
        /// A composed predicate that will first apply this (<em>func</em>) function and then
        /// will apply the after predicate.
        /// </returns>
        public static Predicate<T> AndThen<T, R>(this Func<T, R> func, Predicate<R> after)
        {
            return obj => after(func(obj));
        }

    }

}