using System;
using Autofac;
using IyeTek.BlackJack.Core.Commands;
using IyeTek.BlackJack.Infrastructure.Commands;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class CommandModule : DomainModule
    {
        public override Type ConcreteType
        {
            get { return typeof (Command); }
        }
        
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PassTurnCommand>().As<Command>();
            builder.RegisterType<TakeTurnCommand>().As<Command>().AsSelf();

            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();

        }
        
    }
}