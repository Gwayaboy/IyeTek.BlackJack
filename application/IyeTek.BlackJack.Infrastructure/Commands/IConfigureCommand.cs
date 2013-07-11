using IyeTek.BlackJack.Core.Commands;

namespace IyeTek.BlackJack.Infrastructure.Commands
{
    public interface IConfigureCommand
    {
        IConfigureCommand ConfigureCommand<TCommand>(string action)
            where TCommand : Command;
    }
}