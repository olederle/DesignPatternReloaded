using System;
using System.Linq;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/monad/monad4.java
// * Instead of the Java IllegalStateException we use the .NET InvalidOperationException
// * We do not use the .NET string.IsNullOrEmpty method to implement it the same way as in Java.
// * Instead of the default method Function.andThen we have to use an extension method for this
//   purpose.
// * We have ported the example the same way than the Java version was implemented. However;
//   the new Validate method does not make much sense in .NET, because the implementation does
//   not get easier and concise but rather more vebose. The reason is, that we can not pass
//   a method of the class as first projection parameter which would convert and instance
//   of User to the result type of the passed method. We have to do that manually with an own
//   lambda expression, which makes things more complicated. But anyway, this demonstrates that
//   Java has some capabilites (based on functional interfaces which I really like very much) .NET  
//   does not have.
// * The static Validator.Of method is in an own static utility class which does not use
//   generics, because .NET uses generics in a different way than Java. A static method in
//   a class with type parameters can not be called without specifying the types in .NET.
// * We use an additional Validate method which can be reused in the unit test to prevent code 
//   duplication.

namespace DesignPatternReloaded.Monad
{

    public static class Monad4
    {

        public class Validator<T>
        {
            private readonly T t;
            private readonly InvalidOperationException error;

            internal Validator(T t, InvalidOperationException error)
            {
                this.t = t;
                this.error = error;
            }

            public T Get()
            {
                if (error == null) return t;
                throw error;
            }

            public Validator<T> Validate(Predicate<T> validation, string message)
            {
                if (!validation(t))
                {
                    return new Validator<T>(t, new InvalidOperationException(message));
                }
                return this;
            }

            public Validator<T> Validate<U>(Func<T, U> projection,
                Predicate<U> validation,
                string message)
            {
                return Validate(projection.AndThen(validation), message);
            }

        }

        public static class Validator
        {

            public static Validator<T> Of<T>(T t)
            {
                t.RequireNonNull();
                return new Validator<T>(t, null);
            }

        }

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

        public static Predicate<int> InBetween(int start, int end)
        {
            return value => value > start && value < end;
        }

        public static User Validate(User user)
        {
            return Validator.Of(user)
                .Validate(u => u.Name, name => name != null, "name is null")
                // the original implementation is commented, because that would fail with an ArgumentNullException
                //.Validate(u => u.Name, name => name.Count() > 0, "name is empty")
                .Validate(u => u.Name, name => name == null || name.Count() > 0, "name is empty")
                //.Validate(u => u.Age, age => age > 0 && age < 150, "age is between 0 and 150")
                .Validate(u => u.Age, InBetween(0, 150), "age is between 0 and 150")
                .Get();
        }

        public static void Main(string[] args)
        {
            User user = new User("bob", 12);
            //User user = new User(string.Empty, -12);
            User validatedUser = Validate(user);
            Console.WriteLine(validatedUser.Name + " " + validatedUser.Age);
        }

    }

}