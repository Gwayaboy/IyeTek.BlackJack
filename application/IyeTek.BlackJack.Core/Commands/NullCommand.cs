using System;

namespace IyeTek.BlackJack.Core.Commands
{
    public class NullCommand : Command
    {
        protected NullCommand(): base(null) { }

        public override ExecutionResult Execute()
        {
            return new ExecutionResult();
        }

        private static readonly Lazy<Command> NullCommandInstance = new Lazy<Command>(() => new NullCommand());
        public static Command Instance { get { return NullCommandInstance.Value; }}
    }
}