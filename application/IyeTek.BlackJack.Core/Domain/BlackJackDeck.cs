using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.Core.Domain
{
    
    /// <summary>
    /// This deck redefines the standard deck of 52 cards with revised game value of
    /// jack, queen, king and aces cards for black jack game
    /// </summary>
    public class BlackJackDeck : FiftyTwoCardsDeck
    {
        protected override CardType[] FaceCardTypes
        {
            get { return new[] {BlackJackCardType.Jack, BlackJackCardType.Queen, BlackJackCardType.King }; }
        }

        protected override CardType AceCardType
        {
            get { return BlackJackCardType.Ace; }
        }
    }
}