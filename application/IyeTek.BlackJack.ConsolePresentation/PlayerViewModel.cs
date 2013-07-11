using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.ConsolePresentation
{
    public class PlayerViewModel 
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool CanPlay { get; set; }

        public HandViewModel Hand { get; set; }

        public string Reason { get; set; }

        public int Score { get; set; }
    }

    public class HandViewModel 
    {
        public IList<CardViewModel> Cards { get; set; }
        public IList<CardViewModel> VisibleCards { get { return Cards.Where(c => !c.IsFaceDown).ToList(); } }
    }

    public class CardViewModel
    {
        public bool IsFaceDown { get; set; }
        public CardType CardType { get; set; }
        public SuitType SuitType { get; set; }

       
    }

    public enum CardType
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King

    }
}