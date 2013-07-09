using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _04_Player_looses_immediately_when_goes_bust : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new[]
                    {
                        //Dealer's initial hand worth 17
                        new Card(BlackJackCardType.Ten, SuitType.Clubs),
                        new Card(BlackJackCardType.Seven, SuitType.Spades),

                        //Player's initial hand worth 15
                        new Card(BlackJackCardType.Ten, SuitType.Clubs),
                        new Card(BlackJackCardType.Five, SuitType.Spades),
                  
                        //Player take a 7 card and goes bust
                        new Card(BlackJackCardType.Seven, SuitType.Hearts), 

                        //Dealer stays
                    };
            }
        }

        public void Given_the_Dealer_starts_with_an_Hand_scoring_17() { }

        public void AndGiven_the_Player_starts_with_an_Hand_scoring_15() { }

        public void AndGiven_the_Player_took_a_seven_hearts_Card()
        {
            HumanPlayer.TakeTurn();
        }

        public void AndGiven_the_Dealer_stays() { }

        public void When_resolving_the_issue_of_the_game()
        {
            SUT.ResolveStatuses();
        }

        public void Then_Dealer_should_Win()
        {
            ComputerDealer.Status.Should().Be<Won>();
        }

        public void AndThen_The_Player_should_Loose()
        {
            HumanPlayer.Status.Should().Be<Lost>();
        }
    }
}