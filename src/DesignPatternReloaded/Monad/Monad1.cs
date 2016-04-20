using System;
using System.Linq;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/monad/monad1.java
// * Instead of the Java IllegalStateException we use the .NET InvalidOperationException
// * We do not use the .NET string.IsNullOrEmpty method to implement it the same way as in Java.

namespace DesignPatternReloaded.Monad
{

    public static class Monad1
    {

        public class User
        {

            private readonly string name;
            private readonly int age;

            public string Name { get { return name; } }
            public int Age { get { return age; } }

            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

        }

        public static void Main(string[] args)
        {
            User user = new User("bob", 12);
            //User user = new User(string.Empty, -12);

            if (user.Name == null)
            {
                throw new InvalidOperationException("name is null");
            }

            if (user.Name.Count() == 0)
            {
                throw new InvalidOperationException("name is empty");
            }

            if (!(user.Age > 0 && user.Age < 150))
            {
                throw new InvalidOperationException("age is between 0 and 150");
            }
        }

    }

}