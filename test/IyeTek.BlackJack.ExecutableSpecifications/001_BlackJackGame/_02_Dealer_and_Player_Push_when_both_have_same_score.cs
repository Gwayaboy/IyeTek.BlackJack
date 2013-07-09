using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _02_Dealer_and_Player_Push_when_both_have_same_score : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new[]
                    {
                        //Dealer's initial hand worth 14
                        new Card(BlackJackCardType.Four, SuitType.Clubs),
                        new Card(BlackJackCardType.Ten, SuitType.Spades),

                        //Player's initial hand worth 18
                        new Card(BlackJackCardType.Eight, SuitType.Diamonds),
                        new Card(BlackJackCardType.Ten, SuitType.Hearts),

                        //player take a 2 card and score 20 
                        new Card(BlackJackCardType.Two, SuitType.Spades),

                        //dealer take a 6 card and score 20 
                        new Card(BlackJackCardType.Six, SuitType.Hearts),
                    };
            }
        }

        public void Given_the_Player_took_a_2_Spades_Card()
        {
            HumanPlayer.TakeTurn();
        }

        public void AndGiven_the_Dealer_took_a_6_Hearts_Card()
        {
            ComputerDealer.TakeTurn();
        }

        public void When_resolving_dealer_and_player_statuses()
        {
            SUT.ResolveStatuses();
        }

        public void Then_both_Dealer_and_Player_have_a_tie()
        {
            ComputerDealer.Status.Should().Be<Tied>();
            HumanPlayer.Status.Should().Be<Tied>();
        }
    }
}