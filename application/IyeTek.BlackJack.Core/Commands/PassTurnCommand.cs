using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Commands
{
    public class PassTurnCommand : Command
    {
        private readonly TakeTurnCommand _nextCommand;

        public PassTurnCommand(ICardGame cardGame, TakeTurnCommand nextCommand) : base(cardGame)
        {
            _nextCommand = nextCommand;
        }

        public override ExecutionResult Execute()
        {
            CardGame.GotoNextPlayer();
            return _nextCommand.Execute();
        }
    }
}