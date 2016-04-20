using DesignPatternReloaded.AutoVivification;
using System.Collections.Generic;
using Xunit;
using static DesignPatternReloaded.AutoVivification.AutoVivification2;

namespace DesignPatternReloadedTest.AutoVivification
{

    public class AutoVivification2Test
    {

        [Fact]
        public void Test_AutoVivification2()
        {
            IDictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
            Dict.Get<string, IList<string>> dict = Dict.AsGet(dictionary, () => new List<string>());

            dict("foo").Add("bar");
            dict("foo").Add("baz");

            Assert.Equal(1, dictionary.Count);

            Assert.True(dictionary.ContainsKey("foo"));

            IList<string> list = dictionary["foo"];
            Assert.Equal(2, list.Count);
            Assert.Equal("bar", list[0]);
            Assert.Equal("baz", list[1]);
        }

    }

}