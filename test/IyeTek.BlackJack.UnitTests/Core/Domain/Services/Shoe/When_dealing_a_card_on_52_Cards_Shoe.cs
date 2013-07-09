using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_dealing_a_card_on_52_Cards_Shoe : ShoeServiceSpecification
    {
        private Card _dealtCard;

        public void Given_the_Shoe_has_suffled_a_Deck_of_52_Cards() { }

        public void When_dealing_a_Card()
        {
            _dealtCard =SUT.DealCard();
        }

        public void AndThen_the_dealt_card_should_be_removed_from_the_Shoe()
        {
            SUT.ShuffledCards.Should().NotContain(_dealtCard);
        }

        public void AndThen_the_there_should_be_51_suffled_Cards()
        {
            SUT.ShuffledCards.Should().HaveCount(51);
        }
    }
}