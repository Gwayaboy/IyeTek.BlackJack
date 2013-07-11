using System;
using System.Collections.Generic;
using System.Linq;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.Core.Domain
{
    public abstract class Deck
    {
        public abstract IEnumerable<Card> Cards { get; }
    }

    public class FiftyTwoCardsDeck : Deck
    {
        protected readonly List<Card> _cards = new List<Card>(52);
        private readonly SuitType[] _allSuitsType = (SuitType[])Enum.GetValues(typeof(SuitType));
        public override IEnumerable<Card> Cards { get { return _cards; } }

        private readonly CardType[] _faceCardTypes;
        private readonly CardType _aceCardType;
        private readonly CardType[] _numericalCardTypes;

        public FiftyTwoCardsDeck(CardType[] faceCardTypes,
                                 CardType aceCardType,
                                 CardType[] numericalCardTypes)
        {
            _faceCardTypes = faceCardTypes;
            _aceCardType = aceCardType;
            _numericalCardTypes = numericalCardTypes;
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
            _cards.AddRange(_faceCardTypes.Select(cardType => new Card(cardType, suitType)));
        }

        protected void AddAce(SuitType suitType, int value = 11)
        {
            _cards.Add(new Card(_aceCardType, suitType));
        }

        protected void AddNumericalCards(SuitType suitType)
        {
            var numericalCards = _numericalCardTypes.Select(ct => new Card(ct, suitType));
            _cards.AddRange(numericalCards);
        }
    }
}