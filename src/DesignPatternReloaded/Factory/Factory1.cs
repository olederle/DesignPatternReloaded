using System.Collections.Generic;
using System.Linq;


// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/factory/factory1.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET naming convention for enum values.
// * Use .NET Linq instead of streams.

namespace DesignPatternReloaded.Factory
{

    public static class Factory1
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

        public delegate IVehicle CreateVehicle();

        public static IList<IVehicle> Create5(CreateVehicle createVehicle)
        {
            return Enumerable.Range(0, 5).Select(i => createVehicle()).ToList();
        }

        public static void Main(string[] args)
        {
            CreateVehicle redCarFactory = () => new Car(Color.Red);
            CreateVehicle blueMotoFactory = () => new Moto(Color.Blue);

            System.Console.WriteLine(Create5(redCarFactory));
            System.Console.WriteLine(Create5(blueMotoFactory));
        }

    }

}