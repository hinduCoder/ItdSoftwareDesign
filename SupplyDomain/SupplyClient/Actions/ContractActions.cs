using System;
using System.Linq;
using System.Net.Mime;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;
using SupplyDomain.Api;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyClient
{
    public class ContractActions : IAction
    {
        private ContractApi _contractsApi;
        private ItemApi _itemApi; 

        public ContractActions(ContractApi contractsApi, ItemApi itemApi)
        {
            _contractsApi = contractsApi;
            _itemApi = itemApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var contractNumber = context.InputString("Введите номер контракта");
            var contractStartDate = context.InputDateTime("Введите дату начала действия договора");
            var contractCloseDate = context.InputDateTime("Введите дату окончания действия договора");
            var contractParticipant = context.InputString("Введите клиента");
            var contractMonthRepetition = context.InputInt("Введите периодичность");
            var contract = new ContractInput{ 
                Number = contractNumber, 
                Period = new Period(contractStartDate, contractMonthRepetition, contractCloseDate),
                Participant = contractParticipant
            };
            ChooseItemsForContract(context, contract);
            _contractsApi.AddNewContract(contract);
        }


        public void ChooseItemsForContract(ActionExecutionContext context, ContractInput contract)
        {
            var itemsSubMenu = new MenuBuilder().Repeatable().Title("Выбора товара");
            var items = _itemApi.GetAllItems();
            foreach (var item in items)
            {
                var itemCaptured = item;
                itemsSubMenu.Item()
                    .AlwaysAvailable()
                    .Title(item.Name)
                    .Action(ctx => AddNewOrderedItem(ctx, itemCaptured.Id, contract));
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void AddNewOrderedItem(ActionExecutionContext context, Guid itemId, ContractInput contractInput)
        {
            var quantity = context.InputInt("Введите количество товара");
            var orderedItemInput = new OrderedItemInput {Quantity = quantity, ItemId = itemId};
            contractInput.OrderedItems.Add(orderedItemInput);
        } 
    }
}