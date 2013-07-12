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
        public HumanPlayer(IShoeService shoeService,
                           IScoreCalculator scoreCalculator,
                           string name = "")
            : base(shoeService, scoreCalculator, name)
        {
        }

        public override bool CanTakeDecision
        {
            get { return true; }
        }

        public override void TakeTurn()
        {
            HitCard();
        }
       
    }
}