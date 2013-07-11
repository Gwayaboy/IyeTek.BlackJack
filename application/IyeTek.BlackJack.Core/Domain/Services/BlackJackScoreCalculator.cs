using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain.Services
{
    public class BlackJackScoreCalculator : IScoreCalculator
    {
        public int Calculate(Hand hand)
        {
            var totalScore = 0;
            var firstAce = true;
            foreach (var card in hand.AllCards)
            {
                totalScore += card.GameValue;
                if (card.IsOfType(BlackJackCardType.Ace))
                {
                    if (firstAce)
                    {
                        firstAce = false;
                    }
                    else
                    {
                        totalScore -= 10;
                    }
                }
            }
            return totalScore;
        }
    }
}
