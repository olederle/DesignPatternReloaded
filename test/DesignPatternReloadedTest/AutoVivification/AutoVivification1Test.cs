using DesignPatternReloaded.AutoVivification;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternReloadedTest.AutoVivification
{

    public class AutoVivification1Test
    {

        [Fact]
        public void Test_AutoVivification1()
        {
            IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            dictionary.Get("foo").Add("bar");
            dictionary.Get("foo").Add("baz");

            Assert.Equal(1, dictionary.Count);

            Assert.True(dictionary.ContainsKey("foo"));

            IList<string> list = dictionary["foo"];
            Assert.Equal(2, list.Count);
            Assert.Equal("bar", list[0]);
            Assert.Equal("baz", list[1]);
        }

    }

}