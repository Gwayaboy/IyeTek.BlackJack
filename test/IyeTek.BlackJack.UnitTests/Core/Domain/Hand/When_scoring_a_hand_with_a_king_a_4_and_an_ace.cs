using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Hand
{
    public class When_scoring_a_hand_with_a_king_a_4_and_an_ace : Specification
    {
        private static readonly Card King = new Card(BlackJackCardType.King ,SuitType.Hearts);
        private static readonly Card Ace = new Card(BlackJackCardType.Ace, SuitType.Hearts);
        private static readonly Card Three = new Card(BlackJackCardType.Three, SuitType.Hearts);
        private static readonly Card[] InitialCards = new[] {King, Three, Ace};


        private int _handScore;
        private BlackJack.Core.Domain.Base.Hand SUT { get; set; }

        public void Given_an_hand_contains_3_aces()
        {
            SUT = new BlackJackHand(InitialCards);
        }

        public void When_scoring_the_hand()
        {
            _handScore = SUT.Score;
        }

        public void Then_the_hand_score_should_be_24()
        {
            _handScore.Should().Be(24);
        }
    }
}