using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/builder/builder2.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET Func delegate instead of Java Supplier functional interface.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).

namespace DesignPatternReloaded.Builder
{

    public static class Builder2
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

        public class Builder
        {

            private readonly IDictionary<string, Func<IVehicle>> dict = new Dictionary<string, Func<IVehicle>>();

            public void Register(string name, Func<IVehicle> supplier)
            {
                dict[name] = supplier;
            }

            public CreateVehicle ToFactory()
            {
                return name => dict.GetOrDefault(name, Unknown(name))();
            }

            private static Func<IVehicle> Unknown(string name)
            {
                return () => { throw new ArgumentException(string.Format("Unknown {0}", name)); };
            }
        }

        public delegate IVehicle CreateVehicle(string name);

        public static void Main(string[] args)
        {
            Builder builder = new Builder();
            builder.Register("car", Car.Create);
            builder.Register("moto", Moto.Create);

            CreateVehicle createVehicle = builder.ToFactory();

            IVehicle vehicle1 = createVehicle("car");
            Console.WriteLine(vehicle1);
            IVehicle vehicle2 = createVehicle("moto");
            Console.WriteLine(vehicle2);
        }

    }

}