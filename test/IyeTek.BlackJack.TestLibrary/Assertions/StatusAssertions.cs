using FluentAssertions.Execution;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;

namespace IyeTek.BlackJack.TestLibrary.Assertions
{
    public class StatusAssertions 
    {
        public Status Status { get; private set; }

        public StatusAssertions(Status status)
        {
            Status = status;
        }

        public void Be<TStatus>() where TStatus:Status
        {
            Execute.Verification
                   .ForCondition(Status.Is<TStatus>())
                   .FailWith("Expected status {0} but actual is {1}", typeof (TStatus).Name,
                             Status.GetType().Name);
        }
    }
}