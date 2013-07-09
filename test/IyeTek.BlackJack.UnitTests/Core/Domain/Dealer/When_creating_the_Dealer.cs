using System;
using FluentAssertions;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Dealer
{
    public class When_creating_the_Dealer : Specification
    {
        private static readonly Card SecondCard = new Card(BlackJackCardType.Ten , SuitType.Hearts );
        private static readonly Card FirstCard = new Card(BlackJackCardType.Four, SuitType.Clubs);
        private readonly Card[] _cards = new[] { FirstCard, SecondCard };
        private readonly IShoeService _shoeService = Substitute.For<IShoeService>();

        public void Given_the_shoe_action_on_initial_cards_is_invoked()
        {
            _shoeService
                .When(c => c.MakeInitialHand(Arg.Any<Action<Card[]>>()))
                .Do(c =>
                    {
                        var action = c.Args()[0] as Action<Card[]>;
                        if (action != null) action.Invoke(_cards);
                    });
        }

        public void When_the_Dealer_is_created()
        {
           var dealer = new ComputerDealer(_shoeService);
        }

        public void Then_the_Dealer_Hand_first_Card_Should_not_be_face_down()
        {
            FirstCard.IsFaceDown.Should().BeFalse();
        }

        public void AndThen_the_Dealer_Hand_second_Card_Should_be_face_down()
        {
            SecondCard.IsFaceDown.Should().BeTrue();
        }
    }
}