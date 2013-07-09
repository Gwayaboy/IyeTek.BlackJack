using System;
using FluentAssertions;
using IyeTek.BlackJack.Core;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_dealing_a_card_with_no_remaining_Cards_in_the_Shoe : Specification
    {
        private readonly IDeck _emptyCardDeck = Substitute.For<IDeck>();
        protected ShoeService SUT { get; set; }
        private Action _failingToDealAction;


        public void Given_the_Shoe_has_no_Cards_left()
        {
            _emptyCardDeck.Cards.Returns(new Card[] {});

            SUT = new BlackJackShoeService(_emptyCardDeck);
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