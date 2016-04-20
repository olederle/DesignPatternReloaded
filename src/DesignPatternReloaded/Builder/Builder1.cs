using System;


// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/builder/builder1.java
// * Instead of functional interfacs we have to use delegates.
// * Use .NET Func delegate instead of Java Supplier functional interface.
// * Changes because CLR does not allow to pass a constructor as Func delegate (see below).

namespace DesignPatternReloaded.Builder
{

    public static class Builder1
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
            public void Register(string name, Func<IVehicle> supplier)
            {
                throw new NotImplementedException("TODO");
            }

            public CreateVehicle ToFactory()
            {
                throw new NotImplementedException("TODO");
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