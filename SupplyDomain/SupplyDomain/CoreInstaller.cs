using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SupplyDomain;
using SupplyDomain.DataAccess;
using Component = Castle.MicroKernel.Registration.Component;

namespace SupplyClient
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Where(t => t.Name.EndsWith("Api"))
                .Configure(c => c.Interceptors<LoggerInterceptor>()),
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (MemoryRepository<>)),
                Component.For<LoggerInterceptor>(),
                Component.For<DemoDataGenerator>());
            
        }
    }
}