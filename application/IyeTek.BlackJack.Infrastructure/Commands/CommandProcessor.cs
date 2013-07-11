using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Commands;

namespace IyeTek.BlackJack.Infrastructure.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IEnumerable<Command> _commands;

        public CommandProcessor(IEnumerable<Command> commands)
        {
            _commands = commands;
        }

        public IConfigureCommand ConfigureCommand<TCommand>(string action) where TCommand : Command
        {
            var command = _commands.SingleOrDefault(c => c.GetType() == typeof(TCommand));
            if (command != null)
            {
                command.Action = action;
            }
            return this;
        }

        public ExecutionResult Execute(string action)
        {
            var command = _commands.SingleOrDefault(c => c.Action == action);

            if (command == null)
            {
                var actionIsNotSupported = string.Format("action {0} is not supported",action);
                return new ExecutionResult(new []{actionIsNotSupported});
            }
            return command.Execute();
        }
    }
}