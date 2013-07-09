using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Cards
{
    public class When_comparing_different_Card_Type : Specification
    {
        private bool _result;
        protected Card SUT { get; set; }
         
        public void Given_the_Card_Type_is_Black_Jack_Ace()
        {
            SUT = new Card(BlackJackCardType.Ace, SuitType.Spades);
        }

        public void When_comparing_to_a_regular_ace()
        {
            _result = SUT.IsOfType(CardType.Ace);
        }
        public void Then_the_result_should_be_false()
        {
            _result.Should().BeFalse();
        }

    }
}