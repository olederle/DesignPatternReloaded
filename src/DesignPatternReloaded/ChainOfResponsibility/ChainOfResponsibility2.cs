using DesignPatternReloaded.ChainOfResponsibility.Extensions2;
using DesignPatternReloaded.Extensions;
using DesignPatternReloaded.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static DesignPatternReloaded.ChainOfResponsibility.ChainOfResponsibility2;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/chainofresponsibility/chainofresponsibility2.java
// * .NET does not support Enums with methods for that reason we use extension methods
//   and a static utility class.
// * .NET does not support static methods in interfaces for that reason we use an abstract
//   base class instead of the interface.
// * Implemented something similar than the Java Optional class which isn't present in .NET
//   by default. Implemented also some extension methods to use Optional in relation with
//   Linq.

namespace DesignPatternReloaded.ChainOfResponsibility
{

    namespace Extensions2
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

    public static class ChainOfResponsibility2
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

            public static Optional<Expr> ParseValue(string token)
            {
                try
                {
                    return Optional.Of<Expr>(new Value(double.Parse(token)));
                }
                catch (FormatException)
                {
                    return Optional.Empty<Expr>();
                }
            }

            public static Optional<Expr> ParseVariable(string token)
            {
                return Optional.Of<Expr>(new Variable(token));
            }

            public static Optional<Expr> ParseBinaryOp(string token, Func<Expr> supplier)
            {
                return Operators.Parse(token)
                    .Select<Expr>(op => new BinaryOp(op, supplier(), supplier()));
            }

            public static Expr Parse(IEnumerator<string> enumerator)
            {
                enumerator.MoveNext();
                string token = enumerator.Current;
                Optional<Expr> expr = ParseBinaryOp(token, () => Parse(enumerator));
                if (!expr.HasValue)
                {
                    expr = ParseValue(token);
                    if (!expr.HasValue)
                    {
                        expr = ParseVariable(token);
                    }
                }
                return expr.OrElseThrow(() => new InvalidOperationException("illegal token " + token));
            }
        }

        public static void Main(string[] args)
        {
            Expr expr = Expr.Parse("+ 2 * a 3".Split(' ').AsEnumerable().GetEnumerator());
            Console.WriteLine(expr);
        }

    }

}