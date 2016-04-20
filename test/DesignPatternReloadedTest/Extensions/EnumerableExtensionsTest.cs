using DesignPatternReloaded.Extensions;
using DesignPatternReloaded.Util;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternReloadedTest.Extensions
{

    public class EnumerableExtensionsTest
    {

        [Fact]
        public void Test_FirstAsOptional_EmptyEnumerable()
        {
            IEnumerable<string> enumerable = new string[0];
            Optional<string> optional = enumerable.FirstAsOptional();
            Assert.NotNull(optional);
            Assert.False(optional.HasValue);
        }

        [Fact]
        public void Test_ForEach_EmptyEnumerable()
        {
            IEnumerable<string> enumerable = new string[0];
            IList<string> collector = new List<string>();
            enumerable.ForEach(s => collector.Add(s));
            Assert.Equal(0, collector.Count);
        }

        [Fact]
        public void Test_ForEach_Values()
        {
            IEnumerable<string> enumerable = new string[] { "one", "two" };
            IList<string> collector = new List<string>();
            enumerable.ForEach(s => collector.Add(s));
            Assert.Equal(2, collector.Count);
            Assert.Equal("one", collector[0]);
            Assert.Equal("two", collector[1]);
        }

    }

}