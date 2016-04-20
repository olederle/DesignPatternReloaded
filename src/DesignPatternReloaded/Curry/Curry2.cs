using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/curry/curry2.java
// * Use .NET naming convention for interfaces.
// * Use IDictionary/Dictionary instead of HashMap.
// * Instead of IllegalArgumentException we have to use ArgumentException.
// * Instead of the built-in HashMap.getOrDefault method we have to use an own extension method.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).
// * We use an additional CreateVehicleFactoryMethod method which can be reused in the unit test
//   to prevent code duplication.

namespace DesignPatternReloaded.Curry
{

    public static class Curry2
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

        public static Func<string, string, IVehicle> CreateVehicleFactoryMethod()
        {
            IDictionary<string, Color> colorMap = new Dictionary<string, Color>();
            colorMap.Add("blue", Color.Blue);
            colorMap.Add("violet", Color.Magenta);
            Func<string, Color> colorFactory = name => colorMap.GetOrDefault(name, Color.Black);

            IDictionary<string, Func<Color, IVehicle>> shapeMap
                = new Dictionary<string, Func<Color, IVehicle>>();
            shapeMap.Add("car", Car.Create);
            shapeMap.Add("moto", Moto.Create);
            Func<string, Func<Color, IVehicle>> vehicleFactory = kind => shapeMap.GetOrDefault(
                kind,
                k => { throw new ArgumentException("unknown kind " + k, nameof(kind)); });

            // To visualize all the calls we use Invoke explicitly. See the alternate version below
            // to write this more compact.
            return (kind, colorName) => vehicleFactory
                .Invoke(kind)
                .Invoke(colorFactory.Invoke(colorName));
            // alternate version
            //return (kind, colorName) => vehicleFactory(kind)(colorFactory(colorName));
        }

        public static void Main(string[] args)
        {
            Func<string, string, IVehicle> createVehicle = CreateVehicleFactoryMethod();

            IVehicle vehicle = createVehicle("car", "violet");
            Console.WriteLine(vehicle);
        }

    }

}