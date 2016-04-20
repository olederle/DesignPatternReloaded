using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor0.java
// * Use .NET naming convention for interfaces.
// * Instead of an anonymous class we use a named class.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor0
    {

        public interface IVehicle
        {
            R Accept<R>(Visitor<R> visitor);
        }

        public class Car : IVehicle
        {
            public R Accept<R>(Visitor<R> visitor)
            {
                return visitor.VisitCar(this);
            }
        }

        public class Moto : IVehicle
        {
            public R Accept<R>(Visitor<R> visitor)
            {
                return visitor.VisitMoto(this);
            }
        }

        public class Visitor<R>
        {
            public virtual R VisitMoto(Moto moto)
            {
                throw new NotImplementedException();
            }

            public virtual R VisitCar(Car car)
            {
                throw new NotImplementedException();
            }
        }

        // .NET does not support anonymous classes.
        public class DefaultVisitor : Visitor<string>
        {
            public override string VisitCar(Car car)
            {
                return "car";
            }
            public override string VisitMoto(Moto moto)
            {
                return "moto";
            }
        }

        public static void Main(string[] args)
        {
            Visitor<string> visitor = new DefaultVisitor();
            IVehicle vehicle = new Car();
            string text = vehicle.Accept(visitor);
            Console.WriteLine(text);
        }

    }

}