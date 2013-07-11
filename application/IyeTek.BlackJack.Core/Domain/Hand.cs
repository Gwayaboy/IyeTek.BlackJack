using System.Collections.Generic;
using System.Linq;

namespace IyeTek.BlackJack.Core.Domain
{
    
    public class Hand 
    {
        private readonly List<Card> _cards;

        public IEnumerable<Card> AllCards { get { return _cards; } }
        public IEnumerable<Card> VisibleCards { get { return _cards.Where(c => c.IsFaceDown == false); } }

        public Hand(IEnumerable<Card> cards)
        {
            _cards = new List<Card>(cards);
        }

        public void Add(Card newCard)
        {
            _cards.Add(newCard);
        }

        public void RevealHiddenCards()
        {
            foreach (var hiddenCard in _cards.Where(c => c.IsFaceDown))
            {
                hiddenCard.IsFaceDown = false;
            }
        }
    }
}