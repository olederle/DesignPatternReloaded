using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/abstractfactory/abstractfactory2.java
// * Use .NET naming convention for interfaces.
// * Use IDictionary/Dictionary instead of HashMap.
// * Instead of IllegalArgumentException we have to use ArgumentException.
// * Instead of the Supplier functional Java interface we have to use the Func delegate.
// * Instead of the built-in HashMap.getOrDefault method we have to use an own extension method.
// * We use an additional ConfigureFactory method which can be reused in the unit test.

namespace DesignPatternReloaded.AbstractFactory
{

    public static class AbstractFactory2
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {
            public override string ToString()
            {
                return "Car ";
            }
        }

        public class Moto : IVehicle
        {
            public override string ToString()
            {
                return "Moto ";
            }
        }

        public class VehicleFactory
        {
            private readonly IDictionary<string, Func<IVehicle>> dict = new Dictionary<string, Func<IVehicle>>();

            public void Register(string name, Func<IVehicle> supplier)
            {
                dict.Add(name, supplier);
            }

            public IVehicle Create(string name)
            {
                return dict.GetOrDefault(name,
                    () => { throw new ArgumentException(string.Format("unknown {0}", name), nameof(name)); })
                    .Invoke(); // explicit call which could also be written as "()" in .NET.
            }
        }

        public static VehicleFactory ConfigureFactory()
        {
            VehicleFactory factory = new VehicleFactory();
            factory.Register("car", () => new Car());
            factory.Register("moto", () => new Moto());
            return factory;
        }

        public static void Main(string[] args)
        {
            VehicleFactory factory = ConfigureFactory();

            IVehicle vehicle1 = factory.Create("car");
            Console.WriteLine(vehicle1);
            IVehicle vehicle2 = factory.Create("moto");
            Console.WriteLine(vehicle2);
        }

    }

}