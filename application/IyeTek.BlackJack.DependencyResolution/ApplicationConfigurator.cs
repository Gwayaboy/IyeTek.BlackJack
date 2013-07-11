using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.DependencyResolution.Modules;
using IyeTek.BlackJack.Infrastructure.Commands;

namespace IyeTek.BlackJack.DependencyResolution
{
    public class ApplicationConfigurator
    {
        private static IContainer Container { get; set; }
        private static Assembly ThisAssembly { get { return typeof(ApplicationConfigurator).Assembly; } }

        private static readonly Lazy<ICardGame> _cardGame = new Lazy<ICardGame>(() => Container.Resolve<ICardGame>());
        public static ICardGame CardGame { get { return _cardGame.Value; } }

        private static readonly Lazy<ICommandProcessor> _commandProcessor = new Lazy<ICommandProcessor>(() => Container.Resolve<ICommandProcessor>());

        public static ICommandProcessor CommandProcessor { get {return  _commandProcessor.Value; } }

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            ConfigureBlackJackGameDependencies();
            builder.RegisterAssemblyModules(ThisAssembly);
            Container = builder.Build();
        }

      
        private static void ConfigureBlackJackGameDependencies()
        {
            DeckModule.WithAceCardType(BlackJackCardType.Ace);
            DeckModule.WithFaceCardTypes(BlackJackCardType.King,
                                         BlackJackCardType.Queen,
                                         BlackJackCardType.Jack);

            DomainServiceModule.WithShoeService(c => new BlackJackShoeService(c.Resolve<FiftyTwoCardsDeck>()));
            DomainServiceModule.WithScoreCalculator(c => new BlackJackScoreCalculator());

            DomainServiceModule.WithCardGame(c => new BlackJackCardGame(DealerModule.ResolveDealer(c),
                                                                        c.Resolve<IEnumerable<Player>>(),
                                                                        c.Resolve<IShoeService>()));
        }
    }
}