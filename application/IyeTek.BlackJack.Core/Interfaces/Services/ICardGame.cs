using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Interfaces.Services
{
    public interface ICardGame 
    {
        void ResolveStatuses();

        T Get<T>(int playerNumber = 1) where T : Player;
        IEnumerable<Player> AllPlayers { get; }
        Player CurrentPlayer { get; }
        Player GotoNextPlayer();
        void Reset();
    }
   
}