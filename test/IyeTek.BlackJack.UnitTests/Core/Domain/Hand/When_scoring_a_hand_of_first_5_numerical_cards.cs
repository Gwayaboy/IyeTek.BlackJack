using System.Linq;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Hand
{
    public class When_scoring_a_Hand_of_first_5_numerical_Cards : Specification
    {

        private static readonly Card[] FiveNumericalCards =
            CardType
                .All
                .Where(ct => ct.GameValue >= 2 && ct.GameValue <= 6)
                .Select(ct => new Card(ct, SuitType.Hearts))
                .ToArray();


        private int _handScore;

        protected BlackJackHand SUT { get; set; }

        public void Given_an_Hand_contains_5_first_numerical_Cards()
        {
            SUT = new BlackJackHand(FiveNumericalCards);
        }

        public void When_scoring_the_hand()
        {
            _handScore = SUT.Score;
        }

        public void Then_the_hand_score_should_be_20()
        {
            _handScore.Should().Be(20);
        }

    }
}