using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Player
{
    public class When_Player_takes_turn_with_blackJack_Hand : PlayerSpecification
    {
        private readonly Card _someCard = new Card(BlackJackCardType.Two, SuitType.Spades);

        public void Given_the_Player_hand_is_over_21()
        {
            SUT.Hand.Score.Returns(22);
            ShoeService.DealCard().Returns(_someCard);
        }

        public void When_the_Player_takes_turn()
        {
            SUT.TakeTurn();
        }

        public void Then_the_Player_looses_immediately()
        {
            SUT.Status.Should().Be<Lost>();
        }

        public void AndThen_the_Shoe_should_deal_1_Card()
        {
            ShoeService.Received(1).DealCard();
        }

        public void AndThen_the_Dealer_should_take_the_5_Hearts_Card()
        {
            SUT.Hand.Received(1).Add(_someCard);
        }
    }
}