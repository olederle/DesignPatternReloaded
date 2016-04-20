using DesignPatternReloaded.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// .NET implementation of: https://github.com/forax/design-pattern-reloaded/blob/master/src/main/java/command/command3.java
// * Instead of functional interfaces we have to use delegates.
// * Implemented a ForEach extension method for enumerables to have something similar
//   than in Java.

namespace DesignPatternReloaded.Command
{

    public static class Command3
    {

        public static class CommandLineParser
        {

            public delegate void Register(string name, string description, Action action);

            public delegate void Parse(string[] args);

            public static Parse Create(Action<Register, Action> consumer)
            {
                StringBuilder helpBuilder = new StringBuilder();
                Action help = () => Console.Write(helpBuilder);
                IDictionary<string, Action> actionMap = new Dictionary<string, Action>();
                consumer((name, description, action) =>
                {
                    actionMap.Add("-" + name, action);
                    helpBuilder.Append(name)
                        .Append(": ")
                        .Append(description)
                        .Append(Environment.NewLine);
                }, help);
                return args => args.Where(arg => arg.StartsWith("-"))
                    .Select(arg => actionMap.GetOrDefault(arg, () => help()))
                    .ForEach(action => action());
            }

        }

        public static void Main(string[] args)
        {
            CommandLineParser.Create((opt, ctx) =>
            {
                opt("a", "print all info", () => Console.WriteLine("see -a"));
                opt("help", "print this help", ctx);
            })(args);
        }

    }

}