using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/structuraltyping/ducktyping.java

namespace DesignPatternReloaded.StructuralTyping
{

    public class Ducktyping
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

        public static void Print(object o)
        {
            o.GetType().GetMethod("M").Invoke(o, null);
        }

        public static void Main(string[] args)
        {
            Print(new A());
            Print(new B());
        }

    }

}