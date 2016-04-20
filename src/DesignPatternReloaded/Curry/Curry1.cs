using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/curry/curry1.java
// * Use .NET naming convention for interfaces.
// * Use IDictionary/Dictionary instead of HashMap.
// * Instead of IllegalArgumentException we have to use ArgumentException.
// * Instead of the built-in HashMap.getOrDefault method we have to use an own extension method.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).

namespace DesignPatternReloaded.Curry
{

    public static class Curry1
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

        private static Color GetColor(string name)
        {
            return ColorMap.GetOrDefault(name, Color.Black);
        }

        private static readonly IDictionary<string, Color> ColorMap = CreateColorMap();

        private static IDictionary<string, Color> CreateColorMap()
        {
            IDictionary<string, Color> colorMap = new Dictionary<string, Color>();
            colorMap.Add("blue", Color.Blue);
            colorMap.Add("violet", Color.Magenta);
            return colorMap;
        }

        private static Func<Color, IVehicle> GetVehicleFactory(string kind)
        {
            return VehicleFactoryMap.GetOrDefault(kind,
                k => { throw new ArgumentException("unknown kind " + k, nameof(kind)); });
        }

        private static readonly IDictionary<string, Func<Color, IVehicle>> VehicleFactoryMap = CreateVehicleFactory();

        private static IDictionary<string, Func<Color, IVehicle>> CreateVehicleFactory()
        {
            IDictionary<string, Func<Color, IVehicle>> factoryMap
                = new Dictionary<string, Func<Color, IVehicle>>();
            factoryMap.Add("car", Car.Create);
            factoryMap.Add("moto", Moto.Create);
            return factoryMap;
        }

        public static IVehicle CreateVehicle(string kind, string colorName)
        {
            Func<Color, IVehicle> vehicleFactory = GetVehicleFactory(kind);
            Color color = GetColor(colorName);
            return vehicleFactory(color);
        }

        public static void Main(string[] args)
        {
            IVehicle vehicle = CreateVehicle("car", "violet");
            Console.WriteLine(vehicle);
        }

    }

}