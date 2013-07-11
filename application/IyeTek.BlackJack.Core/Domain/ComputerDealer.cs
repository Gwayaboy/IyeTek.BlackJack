
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain
{
    
    /// <summary>
    /// Implementations of a computed dealer that handles taking cards until the score is more or equal to 17
    /// </summary>
    public class ComputerDealer : Player
    {
        
        public ComputerDealer(IShoeService shoeService, IScoreCalculator scoreCalculator)
            : base(shoeService, scoreCalculator)
        {
        }

        protected override void MakeInitialHand()
        {
             Hand = ShoeService.MakeInitialHand(HideSecondCard);
        }
        
        /// <summary>
        /// Reveal the hidden card first and try not to go bust
        /// </summary>
        public override void TakeTurn()
        {
            Hand.RevealHiddenCards();
            TakeCardsUntilHandScoreIsSevenTeenOrMore();
        }
        
        /// <summary>
        /// When the initial hand his made put the the second card of the pair face down
        /// </summary>
        private static void HideSecondCard(Card[] cards)
        {
            cards[1].IsFaceDown = true;
        }

        private void TakeCardsUntilHandScoreIsSevenTeenOrMore()
        {
            var score = Score;
            while (score <= 17)
            {
                score = HitCard();
            }
        }
    }
}