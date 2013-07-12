using System;
using System.Collections.Generic;
using Autofac;
using IyeTek.BlackJack.Core.Commands;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Services;
using Module = Autofac.Module;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class DomainServiceModule : Module
    {
        private static Func<IComponentContext, IShoeService> _shoeServiceConstructor =
            c => new BlackJackShoeService(c.Resolve<FiftyTwoCardsDeck>());

        public static void WithShoeService<T>(Func<IComponentContext, T> shoeServiceConstructor)
            where T : class, IShoeService
        {
            _shoeServiceConstructor = shoeServiceConstructor;
        }

        private static Func<IComponentContext, IScoreCalculator> _scoreCalculatorConstructor = 
            c => new BlackJackScoreCalculator();
        public static void WithScoreCalculator<T>(Func<IComponentContext, T> scoreCalculatorConstructor)
            where T : class, IScoreCalculator
        {
            _scoreCalculatorConstructor = scoreCalculatorConstructor;
        }

        private static Func<IComponentContext, ICardGame> _cardGameConstructor =
            c => new BlackJackCardGame(DealerModule.ResolveDealer(c),
                                       c.Resolve<IEnumerable<Player>>());

        public static void WithCardGame<T>(Func<IComponentContext, T> cardGameConstructor)
            where T : class, ICardGame
        {
            _cardGameConstructor = cardGameConstructor;
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_shoeServiceConstructor).As<IShoeService>();
            builder.Register(_scoreCalculatorConstructor).As<IScoreCalculator>();
            builder.Register(_cardGameConstructor).As<ICardGame>().SingleInstance();
        }
    }
}