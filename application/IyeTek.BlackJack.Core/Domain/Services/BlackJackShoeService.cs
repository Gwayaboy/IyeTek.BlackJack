using System;
using System.Collections.Generic;
using IyeTek.BlackJack.Core.Interfaces.Domain;

namespace IyeTek.BlackJack.Core.Domain.Services
{
    
    /// <summary>
    /// Receive ore or more decks shuffle it and give an initial hand with a pairs of cards
    /// Any other implementation of how to dispatch an initial hand can derive ShoeService 
    /// </summary>
    public class BlackJackShoeService : ShoeService
    {

        public BlackJackShoeService(IDeck deck) : base(deck)
        {
        }

        public BlackJackShoeService(IEnumerable<IDeck> decks) : base(decks)
        {
        }

        /// <summary>
        /// Serves an Hand made out of 2 initial cards 
        /// </summary>
        /// <returns></returns>
        public override IHand MakeInitialHand(Action<Card[]> actionOnCardsInHand = null)
        {
            var cardsInHand = new[] {DealCard(), DealCard()};
            if (actionOnCardsInHand != null)
            {
                actionOnCardsInHand(cardsInHand);
            }   
            return new BlackJackHand(cardsInHand);
        }
    }

}