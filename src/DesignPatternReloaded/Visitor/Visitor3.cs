using System;
using System.Collections.Generic;
using System.Reflection;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/visitor/visitor3.java
// * Same as for Visitor2
// * In .NET generic types are not erasured as in Java. For that reason the compiler is much
//   more restrictive about generics than the compiler of Java. It isn't possible to do some
//   "dirty tricks" to be smarter than the compiler and use wildcards. The compiler always has
//   to know the type and does not perform any implicit casting which might result in a
//   runtime exception. 
//   In this example we are using reflection. 

namespace DesignPatternReloaded.Visitor
{

    public static class Visitor3
    {

        public interface IVehicle { /* empty */ }

        public class Car : IVehicle { /* empty */ }

        public class Moto : IVehicle { /* empty */ }

        public class Visitor<R>
        {
            private readonly IDictionary<Type, Tuple<object, MethodInfo>> dict 
                = new Dictionary<Type, Tuple<object, MethodInfo>>();

            public Visitor<R> When<T>(Func<T, R> fun)
            {
                MethodInfo methodInfo = fun.GetType().GetMethod(nameof(Func<T, R>.Invoke));
                dict.Add(typeof(T), new Tuple<object, MethodInfo>(fun, methodInfo));
                return this;
            }
            public R Call(object receiver)
            {
                Tuple<object, MethodInfo> tuple;
                dict.TryGetValue(receiver.GetType(), out tuple);
                if (tuple != null)
                {
                    return (R) tuple.Item2.Invoke(tuple.Item1, new object[] { receiver });
                }
                else
                {
                    throw new ArgumentException(string.Format("invalid {0}", receiver));
                }
            }
        }

        public static Visitor<string> ConfigureVisitor()
        {
            Visitor<string> visitor = new Visitor<string>();
            visitor.When<Car>(car => "car")
                .When<Moto>(moto => "moto");
            return visitor;
        }

        public static void Main(string[] args)
        {
            Visitor<string> visitor = ConfigureVisitor();

            IVehicle vehicle = new Car();
            string text = visitor.Call(vehicle);
            Console.WriteLine(text);
        }

    }

}