using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Commands
{
    public class TakeTurnCommand : Command
    {
        public TakeTurnCommand(ICardGame cardGame) : base(cardGame) { }

        public override ExecutionResult Execute()
        {
            var errors = new List<string>();
            var currentPlayer = CardGame.CurrentPlayer;
            
            currentPlayer.TakeTurn();
            if (currentPlayer.Score >= 19)
            {
                CardGame.ResolveStatuses();

                var playerName = GetPlayerName(currentPlayer);

                if (currentPlayer.Status.Is<Won>())
                {
                    errors.Add(string.Format("{0} has won, reason: {1}", playerName, currentPlayer.Status.Reason));
                }
                else if (currentPlayer.Status.Is<Tied>())
                {
                    errors.Add(string.Format("{0} is in a push, reason: {1}", playerName, currentPlayer.Status.Reason));
                }
                else if (currentPlayer.Status.Is<Lost>())
                {
                    errors.Add(string.Format("{0} has lost, reason: {1}", playerName, currentPlayer.Status.Reason));
                }
            }
            
            
            return new ExecutionResult(errors);
        }

        private static string GetPlayerName(Player player)
        {
            var playerName = player.Name;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = player.GetType().Name;
            }
            return playerName;
        }
    }
}