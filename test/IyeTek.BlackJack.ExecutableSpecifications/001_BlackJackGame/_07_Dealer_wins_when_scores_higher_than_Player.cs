using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _07_Dealer_wins_when_scores_higher_than_Player : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new[]
                    {
                        //Dealer's initial hand worth 16
                        new Card(BlackJackCardType.Ten, SuitType.Clubs),
                        new Card(BlackJackCardType.Six, SuitType.Spades),

                        //PLayer's initial hand worth 17
                        new Card(BlackJackCardType.Ten, SuitType.Clubs),
                        new Card(BlackJackCardType.Seven, SuitType.Spades),

                        //PLayer take a 2 card and scores 19
                        new Card(BlackJackCardType.Two, SuitType.Diamonds), 

                        
                        //Dealer take a 4 card and scores 20
                        new Card(BlackJackCardType.Four, SuitType.Hearts), 
                    };
            }
        }

        public void Given_the_Dealer_starts_with_an_Hand_scoring_17() { }

        public void AndGiven_the_Player_starts_with_an_Hand_scoring_16() { }

        public void AndGiven_the_Player_took_a_2_diamonds_Card()
        {
            HumanPlayer.TakeTurn();
        }

        public void AndGiven_the_Dealer_took_a_4_hearts_Card()
        {
            ComputerDealer.TakeTurn();
        }

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