using System.Linq;
using Autofac;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Enumerations;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class DeckModule : Module
    {
        private static CardType[] _faceCardTypes = 
            CardType.All.Where(c => c.GameValue >= 11).ToArray();

        private static CardType[] _numericalCardTypes =
           CardType.All
                   .Where(ct => ct.GameValue >= 2 && ct.GameValue <= 10)
                   .ToArray();
        
        private static CardType _aceCardType = CardType.Ace;


        public static void WithFaceCardTypes(params CardType[] faceCardTypes)
        {
            _faceCardTypes = faceCardTypes;
        }

        public static void WithAceCardType(CardType aceCardType)
        {
            _aceCardType = aceCardType;
        }

        public static void WithNumericalCardTypes(params CardType[] numericalCardTypes)
        {
            _numericalCardTypes = numericalCardTypes;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new FiftyTwoCardsDeck(_faceCardTypes, _aceCardType, _numericalCardTypes))
                .AsSelf();
        }
    }
}