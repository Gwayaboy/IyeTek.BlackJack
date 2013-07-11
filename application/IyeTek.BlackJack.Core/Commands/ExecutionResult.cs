using System.Collections.Generic;
using System.Linq;

namespace IyeTek.BlackJack.Core.Commands
{
    public class ExecutionResult 
    {
        public bool IsSuccessful { get { return !Messages.Any(); } }
        public IEnumerable<string> Messages { get; private set; }

        public ExecutionResult(IEnumerable<string> messages )
        {
            Messages = messages;
        }

        public ExecutionResult() : this(Enumerable.Empty<string>())
        {
            
        }

       
    }
}