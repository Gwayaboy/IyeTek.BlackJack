using FluentAssertions;
using IyeTek.BlackJack.Core.Interfaces.Domain;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_making_the_initial_Hand : ShoeServiceSpecification
    {
        private readonly IHand _hand;
        public void Given_the_Shoe_has_52_Cards() { }

        public When_making_the_initial_Hand()
        {
            _hand = SUT.MakeInitialHand();
        }

        public void Then_the_Shoe_should_have_50_Cards()
        {
            SUT.ShuffledCards.Should().HaveCount(50);
        }

        public void AndThen_the_hand_should_have_2_visible_Cards()
        {
            _hand.VisibleCards.Should().HaveCount(2);
        }

        public void AndThen_the_Dealt_2_Cards_are_no_longer_in_the_Shoe()
        {
            SUT.ShuffledCards.Should().NotContain(_hand.VisibleCards);
        }
    }
}