using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain;

namespace IyeTek.BlackJack.Core.Interfaces.Domain
{
    public interface IHand
    {
        IEnumerable<Card> VisibleCards { get; }

        void Add(Card newCard);

        int Score { get; }

        void RevealHiddenCards();
    }
}