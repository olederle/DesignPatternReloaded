using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://raw.githubusercontent.com/forax/design-pattern-reloaded/master/src/main/java/builder/builder5.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET Func delegate instead of Java Supplier functional interface.
// * Use .NET Action delegate instead of Java Consumer functional interface.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).

namespace DesignPatternReloaded.Builder
{

    public static class Builder5
    {


        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Car Create() { return new Car(); }

            public Car()
            {
            }

            public override string ToString()
            {
                return "Car ";
            }

        }

        public class Moto : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Moto Create() { return new Moto(); }

            public Moto()
            {
            }

            public override string ToString()
            {
                return "Moto ";
            }
        }

        public static Func<K, T> FactoryKit<K, T>(Action<Action<K, T>> consumer, Func<K, T> ifAbsent)
        {
            IDictionary<K, T> dict = new Dictionary<K, T>();
            consumer(dict.Add);
            return key => dict.ComputeIfAbsent(key, ifAbsent);
        }

        public static void Main(string[] args)
        {

            Func<string, Func<IVehicle>> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); });

            IVehicle vehicle1 = factory.Invoke("car")();
            Console.WriteLine(vehicle1);
            IVehicle vehicle2 = factory.Invoke("moto")();
            Console.WriteLine(vehicle2);
        }

    }

}