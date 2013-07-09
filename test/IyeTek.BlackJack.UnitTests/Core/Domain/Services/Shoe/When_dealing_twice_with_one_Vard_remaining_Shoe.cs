using System;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_dealing_twice_with_one_Vard_remaining_Shoe : Specification
    {
        private readonly IDeck _emptyCardDeck = Substitute.For<IDeck>();
        protected ShoeService SUT { get; set; }
        private Action _failingToDealAction;


        public void Given_the_Shoe_has_no_Cards_left()
        {
            _emptyCardDeck.Cards.Returns(new [] { new Card(BlackJackCardType.Ace,SuitType.Hearts), });

            SUT = new BlackJackShoeService(_emptyCardDeck);
            SUT.DealCard();
        }

        public void When_dealing_a_Card()
        {
            _failingToDealAction = () => SUT.DealCard();
        }

        public void Then_an_InvalidOperationException_should_be_thrown()
        {
            _failingToDealAction
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("The Shoe has no card left to be dealt");
        }

    }
}