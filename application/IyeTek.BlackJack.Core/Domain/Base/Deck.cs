using System.Collections.Generic;

namespace IyeTek.BlackJack.Core.Domain.Base
{
    public abstract class Deck
    {
        public abstract IEnumerable<Card> Cards { get; }
    }
}