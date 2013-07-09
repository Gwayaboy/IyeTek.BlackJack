using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Hand
{
    public class When_scoring_a_hand_with_3_aces : Specification
    {
        private static readonly Card[] ThreeAces = new[]
            {
                new Card(BlackJackCardType.Ace, SuitType.Clubs),
                new Card(BlackJackCardType.Ace, SuitType.Hearts),
                new Card(BlackJackCardType.Ace, SuitType.Spades),
            };

        private int _handScore;
        private BlackJack.Core.Domain.Base.Hand SUT { get; set; }

        public void Given_an_hand_contains_3_aces()
        {
            SUT = new BlackJackHand(ThreeAces);
        }

        public void When_scoring_the_hand()
        {
            _handScore = SUT.Score;
        }

        public void Then_the_hand_score_should_be_13()
        {
            _handScore.Should().Be(13);
        }
    }
}