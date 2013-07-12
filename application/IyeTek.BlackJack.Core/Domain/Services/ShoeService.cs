using System;
using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain.Services
{
    /// <summary>
    /// Base class for all shoe, that suffle and deal cards
    /// </summary>
    public abstract class ShoeService : IShoeService
    {
        protected IEnumerable<Deck> Decks { get; private set; }
        protected Stack<Card> SuffledStack = null;

        public IEnumerable<Card> ShuffledCards
        {
            get
            {
                if (SuffledStack == null)
                {
                    SuffledStack = new Stack<Card>();
                    ShuffleCards();
                }
                return SuffledStack;
            }
        }


        protected ShoeService(Deck deck) : this(new[] { deck }) { }

        protected ShoeService(IEnumerable<Deck> decks)
        {
            Decks = decks;
        }

        protected virtual void ShuffleCards()
        {
            var allCards = Decks.SelectMany(d => d.Cards);
            var random = new Random();

            if (SuffledStack == null)
            {
                SuffledStack = new Stack<Card>();
            }
            else
            {
                SuffledStack.Clear();
            }

            allCards
                .OrderBy(x => random.Next())
                .ToList()
                .ForEach(c => SuffledStack.Push(c));
        }

        public Card DealCard()
        {

            if (!ShuffledCards.Any())
            {
                ShuffleCards();
            }

            return SuffledStack.Pop();
        }

        /// <summary>
        /// Depending of the card game a hand may have various number of initial cards
        /// </summary>
        public abstract Hand MakeInitialHand(Action<Card[]> actionOnCardsInHand = null);
    }
}