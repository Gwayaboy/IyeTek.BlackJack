using System;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Interfaces.Domain;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_making_the_initial_Hand_with_action_on_dealt_Card : ShoeServiceSpecification
    {
        private IHand _hand;
        private Card[] _hiddenCars;
        private Action<Card[]> _actionOnCardsInHand;

        public void Given_the_Shoe_has_a_action_callback()
        {
            _actionOnCardsInHand = cards =>
                {
                    _hiddenCars = cards;
                    cards[0].IsFaceDown = true;
                    cards[1].IsFaceDown = true;
                };
        }


        public void When_making_the_initial_Hand()
        {
            _hand = SUT.MakeInitialHand(_actionOnCardsInHand);
        }

        public void Then_the_Shoe_should_have_no_visible_Cards()
        {
            _hand.VisibleCards.Should().BeEmpty();
        }

        public void AndThen_the_hand_should_have_2_face_down_Cards()
        {
            _hiddenCars.Should().HaveCount(2).And.OnlyContain(x => x.IsFaceDown);
        }

        
    }
}