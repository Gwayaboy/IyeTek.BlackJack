using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _05_Player_wins_when_Dealer_goes_bust_and_he_is_not : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new []
                    {
                        //Dealer's initial hand worth 15
                        new Card(BlackJackCardType.Ten, SuitType.Clubs),
                        new Card(BlackJackCardType.Five, SuitType.Spades),

                        //Player's initial hand worth 20
                        new Card(BlackJackCardType.Ten, SuitType.Diamonds),
                        new Card(BlackJackCardType.Ten, SuitType.Hearts),

                        //Player stay with a hand worth 20

                        //Dealer take a 7 card and goes bust
                        new Card(BlackJackCardType.Seven, SuitType.Hearts),
                    };
            }
        }

        public void Given_the_Dealer_starts_with_an_Hand_scoring_15() { }

        public void AndGiven_the_Player_starts_with_an_Hand_scoring_20() { }

        public void AndGiven_the_Player_stays() { }

        public void AndGiven_the_Dealer_took_a_seven_of_Hearts()
        {
            ComputerDealer.TakeTurn();
        }

        public void When_resolving_the_issue_of_the_game()
        {
            SUT.ResolveStatuses();
        }

        public void Then_Dealer_should_Loose()
        {
            ComputerDealer.Status.Should().Be<Lost>();
        }

        public void AndThen_The_Player_should_Win()
        {
            HumanPlayer.Status.Should().Be<Won>();
        }
    }
}