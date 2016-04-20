using System;
using System.Collections.Generic;
using System.Linq;


// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/factory/factory3.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET naming convention for enum values.
// * Use .NET Linq instead of streams.
// * Use .NET Func delegate instead of Java Supplier functional interface.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).

namespace DesignPatternReloaded.Factory
{

    public static class Factory3
    {

        public enum Color { Red, Green, Blue }

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Car Create(Color color) { return new Car(color); }

            private readonly Color color;

            public Car(Color color)
            {
                this.color = color;
            }

            public override string ToString()
            {
                return string.Format("Car {0}", color);
            }

        }

        public class Moto : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Moto Create(Color color) { return new Moto(color); }

            private readonly Color color;

            public Moto(Color color)
            {
                this.color = color;
            }

            public override string ToString()
            {
                return string.Format("Moto {0}", color);
            }
        }

        public static Func<R> Partial<T, R>(Func<T, R> function, T value)
        {
            return () => function(value);
        }

        public static IList<IVehicle> Create5(Func<IVehicle> createVehicle)
        {
            return Enumerable.Range(0, 5).Select(i => createVehicle()).ToList();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(Create5(Partial(Car.Create, Color.Red)));
            Console.WriteLine(Create5(Partial(Moto.Create, Color.Blue)));
        }

    }

}