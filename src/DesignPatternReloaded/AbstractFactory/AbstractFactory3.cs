using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/abstractfactory/abstractfactory3.java
// * Same as for AbstractFactory2
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below)

namespace DesignPatternReloaded.AbstractFactory
{

    public static class AbstractFactory3
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Car Create() { return new Car(); }

            public override string ToString()
            {
                return "Car ";
            }
        }

        public class Moto : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Moto Create() { return new Moto(); }

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
            // CLR does not allow to pass a constructor as Func delegate :-(. Actually, this
            // example can not be ported the same way as it is implemented in Java. 
            // In this example we use a static helper method, which actaully is rather cumbersome.
            // There are plenty of other ways to do something similiar, but none of these solutions
            // is the same than the Java one.
            factory.Register("car", Car.Create);
            factory.Register("moto", Moto.Create);
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