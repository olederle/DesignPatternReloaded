using System;
using System.Collections.Generic;
using System.Linq;


// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/factory/factory2.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET naming convention for enum values.
// * Use .NET Linq instead of streams.
// * Use .NET Func delegate instead of Java Supplier functional interface.

namespace DesignPatternReloaded.Factory
{

    public static class Factory2
    {

        public enum Color { Red, Green, Blue }

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {

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

        public static IList<IVehicle> Create5(Func<IVehicle> createVehicle)
        {
            return Enumerable.Range(0, 5).Select(i => createVehicle()).ToList();
        }

        public static void Main(string[] args)
        {
            Func<IVehicle> redCarFactory = () => new Car(Color.Red);
            Func<IVehicle> blueMotoFactory = () => new Moto(Color.Blue);

            Console.WriteLine(Create5(redCarFactory));
            Console.WriteLine(Create5(blueMotoFactory));
        }

    }

}