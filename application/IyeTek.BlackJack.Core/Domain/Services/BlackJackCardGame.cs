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
    public class BlackJackCardGame : ICardGame
    {
        private readonly IEnumerable<Player> _players;
        private readonly Player _dealer;
        private int _index = 0;

        public IEnumerable<Player> AllPlayers { get { return _players.Union(new[] { _dealer }); } }

        public Player CurrentPlayer { get { return AllPlayers.ElementAtOrDefault(_index%AllPlayers.Count()); } }

        public Player GoToNextPlayer()
        {
            _index++;
            return CurrentPlayer;
        }

        public void Reset()
        {
            _index = 0;
            foreach (var allPlayer in AllPlayers)
            {
                allPlayer.Reset();
            }
        }


        public BlackJackCardGame(Player dealer, IEnumerable<Player> players)
        {
            _players = players;
            _dealer = dealer;
        }

      

        public void ResolveStatuses()
        {
            var notBustedPlayers = _players.Where(IsNotBusted).ToArray();

            // Dealer's hand scores more than 21
            if (IsBusted(_dealer))
            {
                DealerLoosesAndAllOtherPlayersWin(notBustedPlayers);
            }
            // Dealer's hand scores exactly 21
            else if (HasBlackJack(_dealer))
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

        public T Get<T>(int playerNumber = 1) where T : Player
        {
            return AllPlayers.OfType<T>().ElementAtOrDefault(playerNumber - 1);
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
            if (_players.All(IsBusted))
            {
                _dealer.Status = new Won("per forfait, player are busted");
            }
        }

        private void DealerLoosesAndAllOtherPlayersWin(IEnumerable<Player> notBustedPlayers)
        {
            _dealer.Status = new Lost(string.Format("{0} went bust",_dealer.Name)); 
            foreach (var player in notBustedPlayers)
            {
                player.Status = new Won("per forfait, Dealer went bust");
            }
        }

        private void PlayerWithHigherScoreThanDealerWins(Player player)
        {
            if (player.Score > _dealer.Score)
            {
                var playerReason = string.Format("higher score ({0}) than Dealer's ({1})",
                                                 player.Score, _dealer.Score);
                player.Status = new Won(playerReason);

                var dealerReason = string.Format("lower score ({0}) than Player's ({1})",_dealer.Score,player.Score);
                _dealer.Status = new Lost(dealerReason);
            }
        }

        private void PlayerWithLowerScoreThanDealerLooses(Player player)
        {
            if (player.Score < _dealer.Score)
            {
                var playerReason = string.Format("lower score ({0}) than dealer ({1})", player.Score, _dealer.Score);
                player.Status = new Lost(playerReason);

                var dealerReason = string.Format("higher score ({0}) than player ({1})", _dealer.Score,player.Score);
                _dealer.Status = new Won(dealerReason);
            }
        }


        private void DealerAndPlayerWithSameScoreAreInPush(Player player)
        {
            if (player.Score == _dealer.Score)
            {
                var sameScoreAsDealer = string.Format("same score ({0}) as Dealer",player.Score);

                player.Status = new Tied(sameScoreAsDealer);
                _dealer.Status = new Tied(sameScoreAsDealer);
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
            _dealer.Status = new Won("only one with a black jack");
            var blackJackPlayers = notBustedPlayers.Where(HasBlackJack).ToArray();

            if (blackJackPlayers.Any())
            {
                _dealer.Status = new Tied("sharing black jack with another Player");

                foreach (var player in blackJackPlayers)
                {
                    player.Status = new Tied("has black jack and so does the Dealer");
                }
            }
        }
      
    }
}