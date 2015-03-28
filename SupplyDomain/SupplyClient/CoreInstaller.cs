using System.Reflection;
using System.Runtime.InteropServices;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SupplyDomain;
using SupplyDomain.Api;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyClient
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("SupplyDomain").Where(t => t.Name.EndsWith("Api")).WithServiceSelf()
                    .Configure(c => c.Interceptors<LoggerInterceptor>()),
                Classes.FromAssemblyNamed("SupplyDomain").BasedOn(typeof (IRepository<>)).WithServiceBase(),
                Component.For<LoggerInterceptor>(),
                Component.For<DemoDataGenerator>());
            
        }
    }
}