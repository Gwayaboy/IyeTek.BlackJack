using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Interfaces.Domain;

namespace IyeTek.BlackJack.TestLibrary.Fakes
{
    public class SimpleDeck : IDeck
    {
        public IEnumerable<Card> Cards { get; private set; }

        public SimpleDeck(params Card[] cards)
        {
            Cards = cards;
        }
    }
}