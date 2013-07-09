using System;
using FluentAssertions;
using IyeTek.BlackJack.Core;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Hand
{
    public class When_creating_a_hand_with_less_than_2_Cards : Specification
    {
        protected BlackJackHand SUT { get; set; }
        private Action _invalidHandCreation;
        private Card[] _cards;
        
        public void Given_an_Hand_has_only_one_card()
        {
            _cards = new[] { new Card(BlackJackCardType.Four, SuitType.Diamonds) };
        }

        public void When_creating_the_Hand()
        {
            _invalidHandCreation = () => new BlackJackHand(_cards);
        }

        public void Then_a_BusinessRuleException_should_be_thrown()
        {
            _invalidHandCreation
                .ShouldThrow<BusinessRuleException>()
                .WithMessage("The Hand must have 2 initial cards");
        }

    }
}