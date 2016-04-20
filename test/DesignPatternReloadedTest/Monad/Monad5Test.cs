using System;
using Xunit;
using static DesignPatternReloaded.Monad.Monad5;

namespace DesignPatternReloadedTest.Monad
{

    public class Monad5Test
    {

        [Fact]
        public void Test_Monad5_User_WithNullName()
        {
            User user = new User(null, 10);
            AggregateException ex = Assert.Throws<AggregateException>(() => Validate(user));
            Assert.Equal("One or more errors occurred.", ex.Message);
            Assert.Equal(1, ex.InnerExceptions.Count);
            Assert.Equal("name is null", ex.InnerExceptions[0].Message);
        }

        [Fact]
        public void Test_Monad5_User_WithEmptyName()
        {
            User user = new User(string.Empty, 10);
            AggregateException ex = Assert.Throws<AggregateException>(() => Validate(user));
            Assert.Equal("One or more errors occurred.", ex.Message);
            Assert.Equal(1, ex.InnerExceptions.Count);
            Assert.Equal("name is empty", ex.InnerExceptions[0].Message);
        }

        [Fact]
        public void Test_Monad5_User_WithAgeToSmall()
        {
            User user = new User("bob", 0);
            AggregateException ex = Assert.Throws<AggregateException>(() => Validate(user));
            Assert.Equal("One or more errors occurred.", ex.Message);
            Assert.Equal(1, ex.InnerExceptions.Count);
            Assert.Equal("age is between 0 and 150", ex.InnerExceptions[0].Message);
        }

        [Fact]
        public void Test_Monad5_User_WithAgeToBig()
        {
            User user = new User("bob", 151);
            AggregateException ex = Assert.Throws<AggregateException>(() => Validate(user));
            Assert.Equal("One or more errors occurred.", ex.Message);
            Assert.Equal(1, ex.InnerExceptions.Count);
            Assert.Equal("age is between 0 and 150", ex.InnerExceptions[0].Message);
        }

        [Fact]
        public void Test_Monad5_User_Valid()
        {
            User user = new User("bob", 12);
            User validatedUser = Validate(user);
            Assert.NotNull(validatedUser);
            Assert.Same(user, validatedUser);
            Assert.Equal("bob", validatedUser.Name);
            Assert.Equal(12, validatedUser.Age);
        }

    }

}