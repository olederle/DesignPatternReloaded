using System;
using Xunit;
using static DesignPatternReloaded.Monad.Monad4;

namespace DesignPatternReloadedTest.Monad
{

    public class Monad4Test
    {

        [Fact]
        public void Test_Monad4_User_WithNullName()
        {
            User user = new User(null, 10);
            Exception ex = Assert.Throws<InvalidOperationException>(() => Validate(user));
            Assert.Equal("name is null", ex.Message);
        }

        [Fact]
        public void Test_Monad4_User_WithEmptyName()
        {
            User user = new User(string.Empty, 10);
            Exception ex = Assert.Throws<InvalidOperationException>(() => Validate(user));
            Assert.Equal("name is empty", ex.Message);
        }

        [Fact]
        public void Test_Monad4_User_WithAgeToSmall()
        {
            User user = new User("bob", 0);
            Exception ex = Assert.Throws<InvalidOperationException>(() => Validate(user));
            Assert.Equal("age is between 0 and 150", ex.Message);
        }

        [Fact]
        public void Test_Monad4_User_WithAgeToBig()
        {
            User user = new User("bob", 151);
            Exception ex = Assert.Throws<InvalidOperationException>(() => Validate(user));
            Assert.Equal("age is between 0 and 150", ex.Message);
        }

        [Fact]
        public void Test_Monad4_User_Valid()
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