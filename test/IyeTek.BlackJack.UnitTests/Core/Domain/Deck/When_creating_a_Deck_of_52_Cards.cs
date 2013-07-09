using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.TestLibrary.Specification;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Deck
{
    public class When_creating_a_Deck_of_52_Cards : Specification
    {
        private readonly BlackJackDeck SUT = new BlackJackDeck();
        private static readonly IEnumerable<SuitType> AllSuitTypes = (SuitType[]) Enum.GetValues(typeof (SuitType));

        private static IEnumerable<Card> FourAces
        {
            get { return AllSuitTypes.Select(suit => new Card( BlackJackCardType.Ace, suit)); }
        }

        private static IEnumerable<Card> ThirtySixNumericalCards
        {
            get
            {
                return
                    from suit in AllSuitTypes
                    from cardType in BlackJackCardType.All.Where(ct => ct.GameValue >= 2 && ct.GameValue <= 10)
                    select new Card(cardType, suit);
            }
        }

        protected IEnumerable<Card> TwelveFaceCards
        {
            get
            {
                return
                    from suit in AllSuitTypes
                    from cardType in new[] {BlackJackCardType.King, BlackJackCardType.Queen, BlackJackCardType.King}
                    select new Card(cardType, suit);
            }
        }
        
        public void Then_the_Deck_should_have_52_cards()
        {
            SUT.Cards.Should().HaveCount(52);
        }

        public void AndThen_the_Deck_should_have_1_ace_for_each_suit()
        {
            SUT.Cards.Should().Contain(FourAces);
        }

        public void AndThen_the_Deck_should_have_9_numerical_cards_from_2_to_10_for_each_suit()
        {
            SUT.Cards.Should().Contain(ThirtySixNumericalCards);
        }

        public void AndThen_the_Deck_should_have_4_face_cards_for_each_suit()
        {
            SUT.Cards.Should().Contain(TwelveFaceCards);
        }

       
    }
}
