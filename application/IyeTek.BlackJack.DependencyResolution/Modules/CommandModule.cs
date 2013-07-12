using System;
using Autofac;
using IyeTek.BlackJack.Core.Commands;
using IyeTek.BlackJack.Infrastructure.Commands;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PassTurnCommand>().As<Command>();
            builder.RegisterType<TakeTurnCommand>().As<Command>().AsSelf();

            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();

        }
        
    }
}