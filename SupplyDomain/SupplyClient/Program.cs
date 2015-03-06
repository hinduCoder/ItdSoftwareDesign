﻿
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;

namespace SupplyClient 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var contractsRepository = new MemoryRepository<Contract>();
            var itemsRepository = new MemoryRepository<Item>();
            var contractAction = new ContractActions(contractsRepository, itemsRepository);
            var demoData = new DemoDataGenerator(itemsRepository);
            demoData.Generate();
            
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
                .Exit("Закрыть").GetMenu().Run();
        }
    }
}
