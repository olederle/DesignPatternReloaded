using System;
using System.Collections.Generic;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor4.java
// * Same as for Visitor3
// * We use an addition ConfigureVisitor method which can be reused in the unit test.
// * In .NET generic types are not erasured as in Java. For that reason the compiler is much
//   more restrictive about generics than the compiler of Java. It isn't possible to do some
//   "dirty tricks" to be smarter than the compiler and use wildcards. The compiler always has
//   to know the type and does not perform any implicit casting which might result in a
//   runtime exception. 
//   In this solution we wrap the function in another function which is expecting an object
//   as parameters and explicitely casts this parameter to the actual type. Because we know
//   that this cast will never fail, we can do it.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor4
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Visitor<R>
        {
            private readonly IDictionary<Type, Func<object, R>> dict = new Dictionary<Type, Func<object, R>>();

            public Visitor<R> When<T>(Func<T, R> fun)
            {
                dict.Add(typeof(T), obj => fun((T)obj));
                return this;
            }
            public R Call(object receiver)
            {
                return dict.GetOrDefault(receiver.GetType(),
                    obj => { throw new ArgumentException(string.Format("invalid {0}", obj)); })
                    .Invoke(receiver); // explicit call which could also be written as "(receiver)" in .NET.
            }
        }

        public static Visitor<string> ConfigureVisitor()
        {
            Visitor<string> visitor = new Visitor<string>();
            visitor.When<Car>(car => "car")
                .When<Moto>(moto => "moto");
            return visitor;
        }

        public static void Main(string[] args)
        {
            Visitor<string> visitor = ConfigureVisitor();

            IVehicle vehicle = new Car();
            string text = visitor.Call(vehicle);
            Console.WriteLine(text);
        }

    }

}