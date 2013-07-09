using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Interfaces.Domain;

namespace IyeTek.BlackJack.Core.Domain.Base
{
    /// <summary>
    /// Represents a base class for all hands in cards games
    /// any concrete implementation of a particular hand will need to define how 
    /// to calculate the score (<see cref="BlackJackHand"/>)
    /// </summary>
    public abstract class Hand : IHand
    {
        protected readonly List<Card> Cards = new List<Card>();

        public IEnumerable<Card> VisibleCards { get { return Cards.Where(c => c.IsFaceDown == false); } }
        
        public void Add(Card newCard)
        {
            Cards.Add(newCard);
        }

        public abstract int Score { get; }

        public void RevealHiddenCards()
        {
            foreach (var hiddenCard in Cards.Where(c => c.IsFaceDown))
            {
                hiddenCard.IsFaceDown = false;
            }
        }
    }
}