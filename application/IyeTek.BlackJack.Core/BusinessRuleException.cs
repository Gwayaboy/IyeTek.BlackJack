using System;
using IyeTek.BlackJack.Core.Domain;

namespace IyeTek.BlackJack.Core
{
    /// <summary>
    /// is thrown when any business rule is broken
    /// for example when creating a black jack hand with one one card
    /// <see cref="BlackJackHand"/> 
    /// </summary>
    public class BusinessRuleException : ApplicationException
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}