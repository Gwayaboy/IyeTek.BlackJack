using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Dealer
{
    public class When_Dealer_takes_turn_with_Hand_scoring_10 : DealerSpecification
    {
        private readonly Card _fiveHeartCard = new Card(BlackJackCardType.Five, SuitType.Hearts);
        private readonly Card _threeSpadeCard = new Card(BlackJackCardType.Three, SuitType.Spades);

        public void Given_the_Dealer_has_hand_scoring_10()
        {
            SUT.Hand.Score.Returns(10,15,25);
        }

        public void AndGiven_the_Shoe_will_Deal_5_hearts_and_10_spades_cards()
        {
            ShoeService.DealCard().Returns(_fiveHeartCard, _threeSpadeCard);
        }

        public void When_Dealer_takes_turn()
        {
            SUT.TakeTurn();
        }

        public void Then_the_hidden_card_should_be_revealed()
        {
            SUT.Hand.Received().RevealHiddenCards();
        }

        public void AndThen_the_Shoe_should_deal_2_Cards()
        {
            ShoeService.Received(2).DealCard();
        }

        public void AndThen_the_Dealer_should_take_the_5_Hearts_Card()
        {
            SUT.Hand.Received(1).Add(_fiveHeartCard);
        }

        public void AndThen_the_Dealer_should_take_the_3_Spades_Card()
        {
            SUT.Hand.Received(1).Add(_threeSpadeCard);
        }

        public void AndThen_the_Dealer_should_go_burst()
        {
            SUT.Status.Should().Be<Lost>();
        }

    }
}