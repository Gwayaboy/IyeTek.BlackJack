using System;
using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Interfaces.Services
{
    
    /// <summary>
    /// Abstraction of a shoe for any game cards
    /// </summary>
    public interface IShoeService
    {
        /// <summary>
        /// all shuffled cards
        /// </summary>
        IEnumerable<Card> ShuffledCards { get; }

        /// <summary>
        /// Deal the card on top of stack and remove it for the available cards
        /// </summary>
        /// <returns></returns>
        Card DealCard();
        
        
        /// <summary>
        /// Creates a hand of cards
        /// </summary>
        /// <param name="actionOnCardsInHand">perfom any additional action on the cards to be placed in the hand</param>
        /// <returns>Hand to be given to players</returns>
        Hand MakeInitialHand(Action<Card[]> actionOnCardsInHand = null);
    }
}
