using System;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.Core.Domain
{
    /// <summary>
    /// Represemts a Card in any card games with a face and a game value
    /// The game value comes from <see cref="CardType"/> 
    /// which can be redefined for each card game (<see cref="BlackJackCardType"/>)
    /// For future display purposes the card tells whether it is face down (by default) or up 
    /// </summary>
    public class Card : IComparable
    {
        private readonly CardType _cardType;
        public SuitType SuitType { get; private set; }
        public bool IsFaceDown { get; set; }
        public int GameValue { get { return _cardType.GameValue; } }

        public Card(CardType cardType, SuitType suitType)
        {
            if (cardType == null)
            {
                throw new ArgumentNullException("cardType", "the card type must be specified");
            }
            _cardType = cardType;
            SuitType = suitType;
        }

        public bool IsOfType(CardType cardType)
        {
            return _cardType == cardType;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1} ({2})", _cardType, SuitType, GameValue);
        }

        public override bool Equals(object obj)
        {
            var anotherCard = obj as Card;
            if (anotherCard == null) return false;

            return
                anotherCard._cardType == _cardType &&
                anotherCard.SuitType == SuitType;
        }

        public override int GetHashCode()
        {
            return _cardType.GetHashCode() ^ SuitType.GetHashCode();
        }

        /// <summary>
        /// comparison is done on the game value of the card
        /// </summary>
        public int CompareTo(object obj)
        {
            var otherCard = obj as Card;
            if (otherCard == null) return 1;

            return GameValue.CompareTo(otherCard.GameValue);
        }
    }
}
