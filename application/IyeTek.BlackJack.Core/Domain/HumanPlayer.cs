using System;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.Core.Domain
{
    /// <summary>
    /// Implementation of a human player, no deciision are made here programmatically but are made
    /// by the player
    /// </summary>
    public class HumanPlayer : Player
    {
        public HumanPlayer(IShoeService shoeService, string name = "") : base(shoeService, name)
        {
        }

        public override void TakeTurn()
        {
            HitCard();
        }
       
    }
}