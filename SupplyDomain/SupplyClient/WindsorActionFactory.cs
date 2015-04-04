using System;
using Castle.Windsor;
using Feonufry.CUI.Actions;

namespace SupplyClient
{
    public class WindsorActionFactory : IActionFactory
    {
        private WindsorContainer _container;

        public WindsorActionFactory(WindsorContainer container)
        {
            _container = container;
        }

        public IAction Create(Type type)
        {
            return _container.Resolve(type) as IAction;
        }

        public void Release(IAction action)
        {
            _container.Release(action);
        }
    }
}