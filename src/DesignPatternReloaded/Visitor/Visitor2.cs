using System;
using System.Collections.Generic;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor2.java
// * Same as for Visitor1
// * Use IDictionary/Dictionary instead of HashMap.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor2
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Visitor<R>
        {
            private readonly IDictionary<Type, Func<object, R>> dict = new Dictionary<Type, Func<object, R>>();

            public Visitor<R> When<T>(Func<T, R> fun)
            {
                //dict.Add(typeof(T), fun); // doesn't compile :(
                return this;
            }
            public R Call(object receiver)
            {
                return dict.GetOrDefault(receiver.GetType(),
                    obj => { throw new ArgumentException(string.Format("invalid {0}", obj)); })
                    .Invoke(receiver); // explicit call which could also be written as "(receiver)" in .NET.
            }
        }

        public static void Main(string[] args)
        {
            Visitor<string> visitor = new Visitor<string>();
            visitor.When<Car>(car => "car")
                .When<Moto>(moto => "moto");

            IVehicle vehicle = new Car();
            string text = visitor.Call(vehicle);
            Console.WriteLine(text);
        }

    }

}