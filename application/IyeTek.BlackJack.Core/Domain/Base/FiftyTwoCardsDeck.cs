using System;
using System.Linq;
using System.Collections.Generic;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.Core.Domain.Base
{
    /// <summary>
    /// base 52 Cards Deck
    ///  any concrete 52 card Deck for a specific card game needs to define game values for face cards and aces
    /// and can redefine the numerical cards  ones too
    /// </summary>
    public abstract class FiftyTwoCardsDeck : IDeck
    {
        private readonly List<Card> _cards = new List<Card>(52);
        private readonly SuitType[] _allSuitsType = (SuitType[])Enum.GetValues(typeof(SuitType));
        public IEnumerable<Card> Cards { get { return _cards; } }

        protected abstract CardType[] FaceCardTypes { get; }
        protected abstract CardType AceCardType { get; }
        protected virtual CardType[] NumericalCardTypes
        {
            get
            {
                return CardType.All
                               .Where(ct => ct.GameValue >= 2 && ct.GameValue <= 10)
                               .ToArray();
            }
        }

        protected FiftyTwoCardsDeck()
        {
            AddAll52Cards();
        }

        private void AddAll52Cards()
        {
            foreach (var suit in _allSuitsType)
            {
                AddAce(suit);
                AddNumericalCards(suit);
                AddFaceCards(suit);
            }
        }


        protected void AddFaceCards(SuitType suitType)
        {
            _cards.AddRange(FaceCardTypes.Select(cardType => new Card(cardType, suitType)));
        }

        protected void AddAce(SuitType suitType, int value = 11)
        {
            _cards.Add(new Card(AceCardType, suitType));
        }

        protected void AddNumericalCards(SuitType suitType)
        {
            var numericalCards = NumericalCardTypes.Select(ct => new Card(ct, suitType));
            _cards.AddRange(numericalCards);
        }
    }
}