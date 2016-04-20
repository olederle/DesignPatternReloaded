using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/builder/builder6.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET Func delegate instead of Java Supplier functional interface.
// * Use .NET Action delegate instead of Java Consumer functional interface.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).
// * We use an own AndThen extension method for the Func delegate to provide this built-in Java
//   functionality.

namespace DesignPatternReloaded.Builder
{

    public static class Builder6
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

            Func<string, IVehicle> factory = FactoryKit<string, Func<IVehicle>>(builder =>
            {
                builder.Invoke("car", Car.Create);
                builder.Invoke("moto", Moto.Create);
            },
            name => { throw new ArgumentException(string.Format("unknown vehicle {0}", name)); })
            .AndThen(f => f());

            IVehicle vehicle1 = factory.Invoke("car");
            Console.WriteLine(vehicle1);
            IVehicle vehicle2 = factory.Invoke("moto");
            Console.WriteLine(vehicle2);
        }

    }

}