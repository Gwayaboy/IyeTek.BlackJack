using System;
using System.Reflection;
using IyeTek.BlackJack.Core.Domain.Base;
using Module = Autofac.Module;

namespace IyeTek.BlackJack.DependencyResolution.Modules
{
    public abstract class DomainModule : Module
    {
        protected static Assembly DomainAssembly { get { return typeof(Player).Assembly; } }
        public abstract Type ConcreteType { get; }

        protected bool IsSubClassOfConcreteType(Type canditateType)
        {
            return
                !canditateType.IsAbstract &&
                !canditateType.IsInterface &&
                ConcreteType.IsAssignableFrom(canditateType);
        }

    
    }
}