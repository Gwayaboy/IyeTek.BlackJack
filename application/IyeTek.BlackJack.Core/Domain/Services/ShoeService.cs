using System;
using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain.Services
{
    /// <summary>
    /// Base class for all shoe, that suffle and deal cards
    /// Depends on one or more <see cref="IDeck"/>
    /// </summary>
    public abstract class ShoeService : IShoeService
    {
        protected IEnumerable<IDeck> Decks { get; private set; }
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

        protected ShoeService(IDeck deck) : this(new[] { deck }) { }

        protected ShoeService(IEnumerable<IDeck> decks )
        {
            Decks = decks;
        }

        protected virtual void ShuffleCards()
        {
            var allCards = Decks.SelectMany(d => d.Cards);
            var random = new Random();

            SuffledStack.Clear();
            
            allCards
                .OrderBy(x => random.Next())
                .ToList()
                .ForEach(c => SuffledStack.Push(c));
        }

        public Card DealCard()
        {

            if (!ShuffledCards.Any())
            {
                throw new InvalidOperationException("The Shoe has no card left to be dealt");
            }

            return SuffledStack.Pop();
        }

        /// <summary>
        /// Depending of the card game a hand may have various number of initial cards
        /// </summary>
        public abstract IHand MakeInitialHand(Action<Card[]> actionOnCardsInHand = null);
    }
}