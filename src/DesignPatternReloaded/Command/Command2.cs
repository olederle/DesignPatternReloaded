using DesignPatternReloaded.Command.Extensions2;
using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using static DesignPatternReloaded.Command.Command2;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/command/command2.java
// * .NET does not support Enums with methods. For that reason we use extension methods
//   and a static utility class.
// * Implemented a ForEach extension method for enumerables to have something similar
//   than in Java.

namespace DesignPatternReloaded.Command
{

    namespace Extensions2
    {
        public static class OptionExtensions
        {

            public static string Name(this Option op)
            {
                switch (op)
                {
                    case Option.All: return "a";
                    case Option.Help: return "help";
                    default: throw new ArgumentException(op.ToString());
                }
            }

            public static string Description(this Option op)
            {
                switch (op)
                {
                    case Option.All: return "print all info";
                    case Option.Help: return "print this help";
                    default: throw new ArgumentException(op.ToString());
                }
            }

            public static Action Action(this Option op)
            {
                switch (op)
                {
                    case Option.All: return () => Console.WriteLine("see -a");
                    case Option.Help:
                        return () =>
                            Enum.GetValues(typeof(Option))
                                .OfType<Option>()
                                .Select(option => option.AsString())
                                .ForEach(Console.WriteLine);
                    default: throw new ArgumentException(op.ToString());
                }
            }

            public static string AsString(this Option op)
            {
                return op.Name() + ": " + op.Description();
            }

        }
    }

    public static class Command2
    {

        public enum Option
        {
            All,
            Help
        }

        public static class Options
        {

            private static readonly IDictionary<string, Option> Dict = Enum.GetValues(typeof(Option))
                .OfType<Option>()
                .ToDictionary(op => "-" + op.Name(), op => op);

            public static void Parse(string[] args)
            {
                foreach (string arg in args)
                {
                    if (arg.StartsWith("-"))
                    {
                        Option option = Dict.GetOrDefault(arg, Option.Help);
                        option.Action()();
                    }
                }
            }

        }

        public static void Main(string[] args)
        {
            Options.Parse(args);
        }

    }

}