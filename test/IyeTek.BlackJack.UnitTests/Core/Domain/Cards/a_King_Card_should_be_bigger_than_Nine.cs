using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Cards
{
    public class a_King_Card_should_be_bigger_than_Nine : Specification
    {
        private int _result;
        protected Card FirstCard { get; set; }
        protected Card SecondCard { get; set; }

        public void Given_a_King_Card()
        {
            FirstCard = new Card(BlackJackCardType.King, SuitType.Spades);
        }

        public void AndGiven_a_Nine_Card()
        {
            SecondCard = new Card(BlackJackCardType.Nine, SuitType.Hearts);
        }

        public void When_comparing_the_Card()
        {
            _result = FirstCard.CompareTo(SecondCard);
        }

        public void Then_the_result_should_be_false()
        {
            _result.Should().Be(1);
        }
    }
}