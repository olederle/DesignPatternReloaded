using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/curry/curry3.java
// * Use .NET naming convention for interfaces.
// * Use IDictionary/Dictionary instead of HashMap.
// * Instead of the Consumer functional Java interface we have to use the Action delegate.
// * Instead of IllegalArgumentException we have to use ArgumentException.
// * Instead of the built-in HashMap.computeIfAbsent method we have to use an own extension method.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).
// * We use an additional CreateVehicleFactoryMethod method which can be reused in the unit test
//   to prevent code duplication.

namespace DesignPatternReloaded.Curry
{

    public static class Curry3
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Car Create(Color color) { return new Car(color); }

            private readonly Color color;

            public Car(Color color)
            {
                this.color = color.RequireNonNull();
            }

            public override string ToString()
            {
                return "Car " + color.Name;
            }
        }

        public class Moto : IVehicle
        {

            // Required in .NET to pass this as Func
            public static Moto Create(Color color) { return new Moto(color); }

            private readonly Color color;

            public Moto(Color color)
            {
                this.color = color.RequireNonNull();
            }

            public override string ToString()
            {
                return "Moto " + color.Name;
            }
        }

        private static Func<K, T> Factory<K, T>(Action<Action<K, T>> consumer, Func<K, T> ifAbsent)
        {
            IDictionary<K, T> dict = new Dictionary<K, T>();
            consumer(dict.Add);
            return key => dict.ComputeIfAbsent(key, ifAbsent);
        }

        public static Func<string, string, IVehicle> CreateVehicleFactoryMethod()
        {
            Func<string, Color> colorFactory = Factory<string, Color>(builder =>
            {
                builder("blue", Color.Blue);
                builder("violet", Color.Magenta);
            }, __ => Color.Black);

            Func<string, Func<Color, IVehicle>> vehicleFactoryFactory = Factory<string, Func<Color, IVehicle>>(builder =>
            {
                builder("car", Car.Create);
                builder("moto", Moto.Create);
            }, key => __ => { throw new ArgumentException("unknown kind " + key, nameof(key)); });

            return (kind, colorName) => vehicleFactoryFactory(kind)(colorFactory(colorName));
        }

        public static void Main(string[] args)
        {
            Func<string, string, IVehicle> createVehicle = CreateVehicleFactoryMethod();

            IVehicle vehicle = createVehicle("car", "violet");
            Console.WriteLine(vehicle);
        }

    }

}