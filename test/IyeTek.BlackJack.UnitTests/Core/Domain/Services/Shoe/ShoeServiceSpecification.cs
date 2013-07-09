using System;
using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Services.Shoe
{

    public abstract class ShoeServiceSpecification : Specification
    {
        protected BlackJackShoeService SUT { get; set; }
        protected IDeck Deck = Substitute.For<IDeck>();

        protected virtual List<IDeck> Decks { get { return new List<IDeck> { Deck }; } }

        protected ShoeServiceSpecification()
        {
            Deck.Cards.Returns(Create52Cards());
            SUT = new BlackJackShoeService(Decks);

        }

        protected static IEnumerable<Card> Create52Cards()
        {
            return
                from cardType in BlackJackCardType.All
                from suitType in ((SuitType[]) Enum.GetValues(typeof (SuitType)))
                select new Card(cardType, suitType);
        }
    }
}