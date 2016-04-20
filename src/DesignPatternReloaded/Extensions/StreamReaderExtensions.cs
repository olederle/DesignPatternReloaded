using System.Collections.Generic;
using System.IO;

namespace DesignPatternReloaded.Extensions
{

    /// <summary>
    /// Extension methods for StreamReader.
    /// </summary>
    public static class StreamReaderExtensions
    {

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> to read all lines of the StreamReader.
        /// </summary>
        /// <param name="reader">The reader instance to extend.</param>
        /// <returns>An enumerable with all lines of the stream.</returns>
        public static IEnumerable<string> Lines(this StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
            yield break;
        }

    }

}