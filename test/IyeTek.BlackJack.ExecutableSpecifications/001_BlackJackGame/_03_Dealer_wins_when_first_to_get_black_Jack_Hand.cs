using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Specification;
using IyeTek.BlackJack.TestLibrary.Assertions;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _03_Dealer_wins_when_first_to_get_black_Jack_Hand : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new[]
                    {
                        //Dealer's initial hand worth 10
                        new Card(BlackJackCardType.Five, SuitType.Clubs),
                        new Card(BlackJackCardType.Five, SuitType.Spades),

                        //Player's initial hand worth 12
                        new Card(BlackJackCardType.Two, SuitType.Diamonds),
                        new Card(BlackJackCardType.Jack, SuitType.Hearts),

                        //Player take a card and stay with a hand worth 20
                        new Card(BlackJackCardType.Eight, SuitType.Hearts),

                        //Dealer take a ace card a gets a black jack hand  
                        new Card(BlackJackCardType.Ace, SuitType.Hearts),
                    };
            }
        }

        public void Given_the_Dealer_starts_with_an_Hand_scoring_10() { }

        public void AndGiven_the_Player_starts_with_an_Hand_scoring_12() { }

        public void AndGiven_the_Player_took_a_Eight_Card() 
        { 
            HumanPlayer.TakeTurn();
        }

        public void AndGiven_the_Dealer_took_an_Ace()
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