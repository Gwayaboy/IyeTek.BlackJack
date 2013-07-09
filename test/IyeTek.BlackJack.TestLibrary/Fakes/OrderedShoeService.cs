using System.Linq;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Services;

namespace IyeTek.BlackJack.TestLibrary.Fakes
{
    /// <summary>
    /// for testing purpose only Guarantee the order in which the cards will be dealt
    /// which directly is what cards the shoe has been initialised with
    /// </summary>
    public class OrderedShoeService : BlackJackShoeService
    {
        public OrderedShoeService(params Card[] cards)  : base(new SimpleDeck(cards)) { }

        protected override void ShuffleCards()
        {
            var allCards = Decks.SelectMany(c => c.Cards).Reverse();

            foreach (var card in allCards)
            {
                SuffledStack.Push(card);
            }
        }
       
        
       
    }
}