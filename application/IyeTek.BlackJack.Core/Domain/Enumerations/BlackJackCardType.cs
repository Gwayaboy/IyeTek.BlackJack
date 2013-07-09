using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Domain.Enumerations
{
    /// <summary>
    /// Redefine the gameValue of Ace, Jack, Queen and King Card Type for black Jack game
    /// Any card game can derive from Card Type and redefine the game value of each card type
    /// </summary>
    public class BlackJackCardType : CardType
    {
        public new static CardType Ace = new BlackJackCardType(11, "Ace");
        public new static CardType Jack = new BlackJackCardType(10, "Jack");
        public new static CardType Queen = new BlackJackCardType(10, "Queen");
        public new static CardType King = new BlackJackCardType(10, "King");
        
        protected BlackJackCardType(int gameValue, string displayName) : base(gameValue, displayName)
        {
        }
    }
}