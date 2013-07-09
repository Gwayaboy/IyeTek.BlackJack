using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Hand
{
    public class When_scoring_a_hand_with_1_ace_and_a_king : Specification
    {
        private static readonly Card DiamondAce = new Card(BlackJackCardType.Ace,SuitType.Diamonds);
        private static readonly Card HeartKing = new Card(BlackJackCardType.King,SuitType.Hearts);
        private int _handScore;
        private BlackJackHand SUT { get; set; }

        public void Given_an_hand_contains_1_ace_and_a_king()
        {
            SUT = new BlackJackHand(DiamondAce, HeartKing);
        }

        public void When_scoring_the_hand()
        {
            _handScore = SUT.Score;
        }

        public void Then_the_hand_score_should_be_21()
        {
            _handScore.Should().Be(21);
        }
    }
}