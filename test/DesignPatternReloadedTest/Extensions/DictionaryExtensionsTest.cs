using DesignPatternReloaded.Extensions;
using DesignPatternReloaded.Util;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternReloadedTest.Extensions
{

    public class DictionaryExtensionsTest
    {

        [Fact]
        public void Test_Get_ExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("key", "value");

            Optional<string> value = dict.Get("key");
            Assert.True(value.HasValue);
            Assert.Equal("value", value.Value);
        }

        [Fact]
        public void Test_Get_NonExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("KEY", "value");

            Optional<string> value = dict.Get("key");
            Assert.False(value.HasValue);
            Assert.Throws<InvalidOperationException>(() => value.Value);
        }

        [Fact]
        public void Test_GetOrDefault_ExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("key", "value");

            string value = dict.GetOrDefault("key", "default");
            Assert.Equal("value", value);
        }

        [Fact]
        public void Test_GetOrDefault_NonExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("KEY", "value");

            string value = dict.GetOrDefault("key", "default");
            Assert.Equal("default", value);
        }

        [Fact]
        public void Test_ComputeIfAbsent_ExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("key", "value");

            string value = dict.ComputeIfAbsent("key", k => "computed");
            Assert.Equal("value", value);
        }

        [Fact]
        public void Test_ComputeIfAbsent_NonExistingKey()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("KEY", "value");

            string value = dict.ComputeIfAbsent("key", k => "computed");
            Assert.Equal("computed", value);
        }

    }

}