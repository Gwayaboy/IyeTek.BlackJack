using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Commands
{
    public abstract class Command
    {
        protected ICardGame CardGame { get; private set; }

        public string Action { get; set; }

        public abstract ExecutionResult Execute();

        protected Command(ICardGame cardGame)
        {
            CardGame = cardGame;
        }
    }
}