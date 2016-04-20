using System;

// With the dynamic keyword .NET provides a built-in capability for ducktyping without using
// the reflection API.

namespace DesignPatternReloaded.StructuralTyping
{

    public class Ducktyping1
    {

        public class A
        {
            public void M()
            {
                Console.WriteLine("A::M");
            }
        }

        public class B
        {
            public void M()
            {
                Console.WriteLine("B::M");
            }
        }

        public static void Print(dynamic o)
        {
            o.M();
        }

        public static void Main(string[] args)
        {
            Print(new A());
            Print(new B());
        }

    }

}