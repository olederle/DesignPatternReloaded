using DesignPatternReloaded.ChainOfResponsibility.Extensions1;
using DesignPatternReloaded.Extensions;
using DesignPatternReloaded.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static DesignPatternReloaded.ChainOfResponsibility.ChainOfResponsibility1;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/chainofresponsibility/chainofresponsibility1.java
// * .NET does not support Enums with methods for that reason we use extension methods
//   and a static utility class.
// * .NET does not support static methods in interfaces for that reason we use an abstract
//   base class instead of the interface.
// * Implemented something similar than the Java Optional class which isn't present in .NET
//   by default. Implemented also some extension methods to use Optional in relation with
//   Linq.

namespace DesignPatternReloaded.ChainOfResponsibility
{

    namespace Extensions1
    {
        public static class OperatorExtensions
        {

            public static string Name(this Operator op)
            {
                switch (op)
                {
                    case Operator.Add: return "+";
                    case Operator.Mul: return "*";
                    case Operator.Sub: return "-";
                    default: throw new ArgumentException(op.ToString());
                }
            }

        }
    }

    public static class ChainOfResponsibility1
    {

        public enum Operator
        {
            Add,
            Sub,
            Mul
        }

        public static class Operators
        {

            private static readonly IDictionary<string, Operator> Dict = Enum.GetValues(typeof(Operator))
                .OfType<Operator>()
                .ToDictionary(op => op.Name(), op => op);

            public static Optional<Operator> Parse(string token)
            {
                return Dict.Get(token);
            }

        }

        public class Value : Expr
        {
            private readonly double value;

            public Value(double value)
            {
                this.value = value;
            }

            public override string ToString()
            {
                return Convert.ToString(value);
            }
        }

        public class Variable : Expr
        {
            private readonly string name;

            public Variable(string name)
            {
                this.name = name.RequireNonNull();
            }

            public override string ToString()
            {
                return name;
            }
        }

        public class BinaryOp : Expr
        {
            private readonly Operator op;
            private readonly Expr left;
            private readonly Expr right;

            public BinaryOp(Operator op, Expr left, Expr right)
            {
                this.op = op;
                this.left = left.RequireNonNull();
                this.right = right.RequireNonNull();
            }

            public override string ToString()
            {
                return string.Format("({0} {1} {2})", left, op.Name(), right);
            }
        }

        public abstract class Expr
        {

            public static Expr Parse(IEnumerator<string> enumerator)
            {
                enumerator.MoveNext();
                string token = enumerator.Current;
                Optional<Operator> op = Operators.Parse(token);
                if (op.HasValue)
                {
                    Expr left = Parse(enumerator);
                    Expr right = Parse(enumerator);
                    return new BinaryOp(op.Value, left, right);
                }
                try
                {
                    return new Value(double.Parse(token));
                }
                catch (FormatException)
                {
                    return new Variable(token);
                }
            }
        }

        public static void Main(string[] args)
        {
            Expr expr = Expr.Parse("+ 2 * a 3".Split(' ').AsEnumerable().GetEnumerator());
            Console.WriteLine(expr);
        }

    }

}