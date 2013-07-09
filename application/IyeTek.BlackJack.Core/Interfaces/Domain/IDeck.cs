using System.Collections.Generic;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Services;

namespace IyeTek.BlackJack.Core.Interfaces.Domain
{
    /// <summary>
    /// abstraction of a deck which is used as dependencies on <see cref="ShoeService"/>
    /// </summary>
    public interface IDeck
    {
        IEnumerable<Card> Cards { get;  }
    }
}