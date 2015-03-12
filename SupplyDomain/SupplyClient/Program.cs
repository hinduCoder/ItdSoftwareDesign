using Feonufry.CUI.Menu.Builders;
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
            var contractsRepository = new MemoryRepository<Contract>();
            var itemsRepository = new MemoryRepository<Item>();

            var demoData = new DemoDataGenerator(itemsRepository, contractsRepository);
            demoData.Generate();

            var itemApi = new ItemApi(itemsRepository);
            var contractApi = new ContractApi(contractsRepository);

            var contractAction = new ContractActions(contractApi, itemApi);
            
            new MenuBuilder()
                .Title("Снабжение")
                .Repeatable()
                .Submenu("Добавление контракта")
                    .Item("Введите данные для нового контракта", contractAction)
                    .Exit("Назад")
                    .End()
                .Submenu("Изменение состояний")
                    .Exit("Назад")
                    .End()
                .Submenu("Тест") //TODO убрать неприличное слово
                    .Item("Проверить контракты", c => {/*Todo epta*/ })
                    .Exit("Назад")
                    .End()
                .Exit("Закрыть").GetMenu().Run();
        }
    }
}
