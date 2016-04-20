using System;
using System.Collections.Generic;
using DesignPatternReloaded.Extensions;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor6.java
// * Same as for Visitor5
// * This example adds more type safety to the Visitor5 example. However; the code lines which
//   would result in a compile time error are commented. See the comments below.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor6
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Fruit { /* empty */ }
        
        public class Visitor<U, R>
        {
            private readonly IDictionary<Type, Func<object, R>> dict = new Dictionary<Type, Func<object, R>>();

            public Visitor<U, R> When<T>(Func<T, R> fun) where T : U
            {
                dict.Add(typeof(T), fun.Compose<object, T, R>(o => (T)o));
                return this;
            }
            public R Call(U receiver)
            {
                return dict.GetOrDefault(receiver.GetType(),
                    obj => { throw new ArgumentException(string.Format("invalid {0}", obj)); })
                    .Invoke(receiver); // explicit call which could also be written as "(receiver)" in .NET.
            }
        }
        
        public static Visitor<IVehicle, string> ConfigureVisitor()
        {
            Visitor<IVehicle, string> visitor = new Visitor<IVehicle, string>();
            visitor.When<Car>(car => "car")
                .When<Moto>(moto => "moto");
            //    .When<Fruit>(fruit => "fruit"); // doesn't compile
            return visitor;
        }

        public static void Main(string[] args)
        {
            Visitor<IVehicle, string> visitor = ConfigureVisitor();

            IVehicle vehicle = new Car();
            string text = visitor.Call(vehicle);
            //visitor.Call(new Fruit()); // doesn't compile
            Console.WriteLine(text);
        }

    }

}