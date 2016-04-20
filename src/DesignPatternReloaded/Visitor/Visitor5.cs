using System;
using System.Collections.Generic;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor5.java
// * Same as for Visitor4
// * Contrary to the Class class in Java the .NET Type class does not contain a Cast method
//   which can be passed as a function. For that reason, this example is not really different
//   to the Visitor4 example. Actually, Visitor 5 can not be proted to .NET because of 
//   differences in the language capabilities between Java and .NET.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor5
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Visitor<R>
        {
            private readonly IDictionary<Type, Func<object, R>> dict = new Dictionary<Type, Func<object, R>>();

            public Visitor<R> When<T>(Func<T, R> fun)
            {
                dict.Add(typeof(T), fun.Compose<object, T, R>(o => (T)o));
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