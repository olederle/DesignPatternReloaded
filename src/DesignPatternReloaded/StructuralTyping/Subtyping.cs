using System;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/structuraltyping/subtyping.java

namespace DesignPatternReloaded.StructuralTyping
{

    public class Subtyping
    {

        public interface I
        {
            void M();
        }

        public class A : I
        {
            public void M()
            {
                Console.WriteLine("A::M");
            }
        }

        public class B : I
        {
            public void M()
            {
                Console.WriteLine("B::M");
            }
        }

        public static void Print(I i)
        {
            i.M();
        }

        public static void Main(string[] args)
        {
            Print(new A());
            Print(new B());
        }

    }

}