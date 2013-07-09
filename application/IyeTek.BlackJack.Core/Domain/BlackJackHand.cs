using System.Linq;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.Core.Domain
{
    /// <summary>
    /// This hand is the implementation of a black jack hand that starts with an initial
    /// 2 cards and has is own way of scoring the cards
    /// </summary>
    public class BlackJackHand : Hand
    {
        public BlackJackHand(Card[] cards) 
        {
            if (LessThanTwoValidCards(cards))
            {
                throw new BusinessRuleException("The Hand must have 2 initial cards");
            }
            Cards.AddRange(cards);
        }

        public BlackJackHand(Card firstCard, Card secondCard)
            : this(new[] { firstCard, secondCard })
        { }

        private static bool LessThanTwoValidCards(Card[] cards)
        {
            return cards == null || cards.Length < 2 || cards.Any(c => c == null);
        }

        public override int Score
        {
            get
            {
                var totalScore = 0;
                var firstAce = true;
                foreach (var card in Cards)
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
}