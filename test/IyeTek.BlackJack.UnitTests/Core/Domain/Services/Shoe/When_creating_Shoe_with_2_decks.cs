using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{
    public class When_creating_Shoe_with_2_decks_of_52_Cards : ShoeServiceSpecification
    {
        private static readonly IDeck FirstDeck = Substitute.For<IDeck>();
        private static readonly IDeck SecondDeck = Substitute.For<IDeck>();

        protected override List<IDeck> Decks
        {
            get
            {
                FirstDeck.Cards.Returns(Create52Cards());
                SecondDeck.Cards.Returns(Create52Cards());
                return new List<IDeck> {FirstDeck, SecondDeck};
            }
        }

        private IEnumerable<Card> Cards
        {
            get { return Decks.SelectMany(d => d.Cards).ToList(); }
        }

        
        public void Then_the_shoe_should_contain_the_same_104_cards()
        {
            SUT.ShuffledCards.Should().HaveCount(104).And.Contain(Cards);
        }

        public void AndThen_the_shoe_should_not_be_ordered()
        {
            SUT.ShuffledCards.Should().NotBeAscendingInOrder().And.NotBeDescendingInOrder();
        }



    }
}