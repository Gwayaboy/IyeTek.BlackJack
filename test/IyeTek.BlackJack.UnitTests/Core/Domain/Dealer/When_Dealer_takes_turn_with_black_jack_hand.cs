using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Services;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Dealer
{
    public class When_Dealer_takes_turn_with_black_jack_hand : DealerSpecification
    {
        public void Given_the_Dealer_has_black_jack_hand()
        {
            SUT.Hand.Score.Returns(21);
        }

        public void When_Dealer_takes_turn()
        {
            SUT.TakeTurn();
        }

        public void Then_the_hidden_card_should_be_revealed()
        {
            SUT.Hand.Received().RevealHiddenCards();
        }

        public void AndThen_the_Shoe_should_not_deal_any_Cards()
        {
            ShoeService.DidNotReceive().DealCard();
        }

        public void AndThen_the_Dealer_should_not_take_any_more_cards()
        {
            SUT.Hand.DidNotReceive().Add(Arg.Any<Card>());
        }

    }
}