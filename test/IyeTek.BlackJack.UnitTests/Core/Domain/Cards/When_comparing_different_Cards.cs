using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Cards
{
    public class When_comparing_different_Cards : Specification
    {
        private bool _result;
        protected Card FirstCard { get; set; }
        protected Card SecondCard { get; set; }


        public void Given_the_Card_Type_is_8()
        {
            FirstCard = new Card(BlackJackCardType.Five, SuitType.Spades);
            SecondCard = new Card(BlackJackCardType.Eight, SuitType.Spades);
        }

        public void Then_the_First_and_Second_Card_should_not_be_the_Same()
        {
            FirstCard.Should().NotBe(SecondCard);
        }

    }
}