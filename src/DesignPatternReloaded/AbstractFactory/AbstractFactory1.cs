using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/abstractfactory/abstractfactory1.java
// * Instead of static methods wihin an interface we have to use an abstract base class.

namespace DesignPatternReloaded.AbstractFactory
{
    
    public static class AbstractFactory1
    {

        public abstract class Vehicle
        {

            public static Vehicle Create(string name)
            {
                switch (name)
                {
                    case "car":
                        return new Car();
                    case "moto":
                        return new Moto();
                    default:
                        throw new ArgumentException(string.Format("unknown {0}", name), nameof(name));
                }
            }

        }

        public class Car : Vehicle
        {
            public override string ToString()
            {
                return "Car ";
            }
        }

        public class Moto : Vehicle
        {
            public override string ToString()
            {
                return "Moto ";
            }
        }

        public static void Main(string[] args)
        {
            Vehicle vehicle1 = Vehicle.Create("car");
            Console.WriteLine(vehicle1);
            Vehicle vehicle2 = Vehicle.Create("moto");
            Console.WriteLine(vehicle2);
        }

    }

}