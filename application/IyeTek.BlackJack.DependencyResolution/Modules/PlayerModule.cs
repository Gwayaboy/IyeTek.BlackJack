using System;
using Autofac;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public class PlayerModule : DomainModule
    {
        public override Type ConcreteType
        {
            get { return typeof (Player); }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(DomainAssembly)
                   .Where(IsSubClassOfConcreteType)
                   .Where(IsNotAComputerDealer)
                   .As<Player>();
        }

        private static bool IsNotAComputerDealer(Type candidateType)
        {
            return candidateType != typeof(ComputerDealer);
        }
    }
}