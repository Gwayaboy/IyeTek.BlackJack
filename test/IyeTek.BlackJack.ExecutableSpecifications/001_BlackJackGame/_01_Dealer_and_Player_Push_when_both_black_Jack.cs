using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;
using IyeTek.BlackJack.TestLibrary.Assertions;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.ExecutableSpecifications._001_BlackJackGame
{
    public class _01_Dealer_and_Player_Push_when_both_black_Jack : ScenarioFor<us01_BlackJackGame>
    {
        protected override Card[] CardsInShoe
        {
            get
            {
                return new[]
                    {
                        new Card(BlackJackCardType.Ace, SuitType.Clubs),
                        new Card(BlackJackCardType.Ten, SuitType.Spades),

                        new Card(BlackJackCardType.Ace, SuitType.Diamonds),
                        new Card(BlackJackCardType.Ten, SuitType.Hearts),
                    };
            }
        }

        public void Given_both_dealer_and_player_have_blackjack_Hands() { }


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