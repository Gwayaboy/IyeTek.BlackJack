using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.TestLibrary.Specification;
using NSubstitute;

namespace IyeTek.BlackJack.UnitTests.Core.Domain.Dealer
{
    public abstract class DealerSpecification : Specification
    {
        protected IShoeService ShoeService { get; private set; }
        protected ComputerDealer SUT { get; set; }

        protected DealerSpecification()
        {
            ShoeService = Substitute.For<IShoeService>();
           
            SUT = new ComputerDealer(ShoeService);

        }
    }
}