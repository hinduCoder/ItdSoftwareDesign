using System.Runtime.InteropServices.ComTypes;
using Castle.Windsor;
using Feonufry.CUI.Menu.Builders;
using Feonufry.CUI.Menu.Engine;
using SupplyClient.Actions;
using SupplyDomain;
using SupplyDomain.Api;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyClient 
{
   class Program
   {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new CoreInstaller(), new UIInstaller());

            var demoData = container.Resolve<DemoDataGenerator>();
            demoData.Generate();

            new MenuBuilder().WithActionFactory(new WindsorActionFactory(container))
                .Title("Снабжение")
                .Repeatable()
                .Submenu("Добавление контракта")
                    .Item<ContractActions>("Введите данные для нового контракта")
                    .Exit("Назад")
                    .End()
                .Item<StatusesAction>("Изменить состояния")
                .Item<CheckContractsAction>("Текущие контракты")
                .Item<ArchiveContractsAction>("Архивные контракты")
                .Exit("Закрыть").GetMenu().Run();
        }
    }
}
