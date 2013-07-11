using IyeTek.BlackJack.Core.Commands;

namespace IyeTek.BlackJack.Infrastructure.Commands
{
    public interface ICommandProcessor : IConfigureCommand
    {
        ExecutionResult Execute(string action);
    }
}