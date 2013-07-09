using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Player
{

    public abstract class PlayerSpecification : Specification
    {
        protected IShoeService ShoeService { get; private set; }
        protected HumanPlayer SUT { get; set; }

        protected PlayerSpecification()
        {
            ShoeService = Substitute.For<IShoeService>();

            SUT = new HumanPlayer(ShoeService);

        }
    }
}