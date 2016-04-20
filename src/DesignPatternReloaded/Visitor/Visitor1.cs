using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor1.java
// * Use .NET naming convention for interfaces.
// * In .NET generic types are not erasured as in Java. For that reason we do not need
//   the first "Class<T>" parameter but rather a generic for the method itself.

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor1
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Visitor<R>
        {
            public Visitor<R> When<T>(Func<T, R> fun)
            {
                throw new NotImplementedException("TODO");
            }
            public R Call(object receiver)
            {
                throw new NotImplementedException("TODO");
            }
        }

        public static void Main(string[] args)
        {
            Visitor<string> visitor = new Visitor<string>();
            visitor.When<Car>(car => "car")
                .When<Moto>(moto => "moto");

            IVehicle vehicle = new Car();
            string text = visitor.Call(vehicle);
            Console.WriteLine(text);
        }

    }

}