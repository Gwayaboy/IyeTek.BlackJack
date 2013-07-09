using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;

namespace IyeTek.BlackJack.TestLibrary.Assertions
{
    public static class AssertionsExtensions
    {
        public static StatusAssertions Should(this Status status)
        {
            return new StatusAssertions(status);
        }
    }
}