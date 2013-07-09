using System.Linq;

using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain.Services
{
    
    /// <summary>
    /// Determine the outcome of the game after all players have taken their turns
    /// Gives a reason according to the rules why this or that player wins, looses or ties
    /// </summary>
    public class BlackJackGameService : IGameService
    {

        public IEnumerable<Player> Players { get; private set; }
        public Player Dealer { get; private set; }
        public BlackJackGameService(Player dealer, IEnumerable<Player> players)
        {
            Players = players;
            Dealer = dealer;
        }

        public void ResolveStatuses()
        {
            var notBustedPlayers = Players.Where(IsNotBusted).ToArray();

            // Dealer's hand scores more than 21
            if (IsBusted(Dealer))
            {
                DealerLoosesAndAllOtherPlayersWin(notBustedPlayers);
            }
            // Dealer's hand scores exactly 21
            else if (HasBlackJack(Dealer))
            {
                DealerWinsUnlessAnyOtherPlayersHaveBlackJackWichPlaceThemAllInPush(notBustedPlayers);
                AnyOtherPlayersLoose(notBustedPlayers);
            }
            // Dealer's hand scores less than 21
            else
            {
                foreach (var player in notBustedPlayers)
                {
                    PlayerWithHigherScoreThanDealerWins(player);
                    DealerAndPlayerWithSameScoreAreInPush(player);
                    PlayerWithLowerScoreThanDealerLooses(player);
                }

                DealerWinsWhenAllOtherPlayersWentBusted();
            }
        }
      

        private static bool HasBlackJack(Player player)
        {
            return player.Score == 21;
        }

        private static bool HasNotBlackJack(Player player)
        {
            return player.Score != 21;
        }
        
        private static bool IsBusted(Player player)
        {
            return player.Score > 21;
        }

        private static bool IsNotBusted(Player player)
        {
            return player.Score <= 21;
        }

        private void DealerWinsWhenAllOtherPlayersWentBusted()
        {
            if (Players.All(IsBusted))
            {
                Dealer.Status = new Won("per forfait, player are busted");
            }
        }

        private void DealerLoosesAndAllOtherPlayersWin(IEnumerable<Player> notBustedPlayers)
        {
            Dealer.Status = new Lost(string.Format("{0} went bust",Dealer.Name)); 
            foreach (var player in notBustedPlayers)
            {
                player.Status = new Won("per forfait, Dealer went bust");
            }
        }

        private void PlayerWithHigherScoreThanDealerWins(Player player)
        {
            if (player.Score > Dealer.Score)
            {
                var playerReason = string.Format("higher score ({0}) than Dealer's ({1})",
                                                 player.Score, Dealer.Score);
                player.Status = new Won(playerReason);

                var dealerReason = string.Format("lower score ({0}) than Player's ({1})",Dealer.Score,player.Score);
                Dealer.Status = new Lost(dealerReason);
            }
        }

        private void PlayerWithLowerScoreThanDealerLooses(Player player)
        {
            if (player.Score < Dealer.Score)
            {
                var playerReason = string.Format("lower score ({0}) than dealer ({1})", player.Score, Dealer.Score);
                player.Status = new Lost(playerReason);

                var dealerReason = string.Format("higher score ({0}) than player ({1})", player.Score, Dealer.Score);
                Dealer.Status = new Won(dealerReason);
            }
        }


        private void DealerAndPlayerWithSameScoreAreInPush(Player player)
        {
            if (player.Score == Dealer.Score)
            {
                var sameScoreAsDealer = string.Format("same score ({0}) as Dealer",player.Score);

                player.Status = new Tied(sameScoreAsDealer);
                Dealer.Status = new Tied(sameScoreAsDealer);
            }
        }

        private void AnyOtherPlayersLoose(IEnumerable<Player> notBustedPlayers)
        {
            foreach (var player in notBustedPlayers.Where(HasNotBlackJack))
            {
                player.Status = new Lost(string.Format("lower score ({0}) than black jack",player.Score));
            }
        }

        private void DealerWinsUnlessAnyOtherPlayersHaveBlackJackWichPlaceThemAllInPush(IEnumerable<Player> notBustedPlayers)
        {
            Dealer.Status = new Won("only one with a black jack");
            var blackJackPlayers = notBustedPlayers.Where(HasBlackJack).ToArray();

            if (blackJackPlayers.Any())
            {
                Dealer.Status = new Tied("sharing black jack with another Player");

                foreach (var player in blackJackPlayers)
                {
                    player.Status = new Tied("has black jack and so does the Dealer");
                }
            }
        }
    }
}