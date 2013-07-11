using Autofac;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Interfaces.Services;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class DealerModule : Module
    {
        public static Player ResolveDealer(IComponentContext componentContext)
        {
            return componentContext.ResolveNamed<Player>("dealer");
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ComputerDealer>()
                .Named<Player>("dealer");
        }
    }
}