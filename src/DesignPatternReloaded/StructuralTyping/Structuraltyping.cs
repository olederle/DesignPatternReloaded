using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/structuraltyping/structuraltyping.java
// * The structural typing capabilities of Java are much more sophisticated than the capabilities
//   of .NET. This example can be ported, because .NET is able to convert a method call to
//   a delegate. Other examples, which are working in Java might not work in .NET (i.e. see the
//   Monad5 example).

namespace DesignPatternReloaded.StructuralTyping
{

    public class Structuraltyping
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

        public static void Print(Action o)
        {
            o();
        }

        public static void Main(string[] args)
        {
            Print(new A().M);
            Print(new B().M);
        }

    }

}