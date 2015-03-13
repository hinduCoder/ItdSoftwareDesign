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
            var contractMonthRepetition = context.InputInt("Введите повторябельность"); //TODO Адекватное слово
            var contract = new ContractDto(contractNumber, new Period(contractCloseDate, contractMonthRepetition, contractCloseDate));
            ChooseItemsForContract(context, contract);
            _contractsApi.AddNewContract(contract);
        }


        public void ChooseItemsForContract(ActionExecutionContext context, ContractDto contract)
        {
            var itemsSubMenu = new MenuBuilder().Repeatable().Title("Выбора товара");
            var items = _itemApi.GetAllItems();
            foreach (var item in items)
            {
                var itemCaptured = item;
                itemsSubMenu.Item()
                    .AlwaysAvailable()
                    .Title(item.Name)
                    .Action(ctx => AddNewOrderedItem(ctx, itemCaptured, contract));
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void AddNewOrderedItem(ActionExecutionContext context, ItemDto item, ContractDto contractDto)
        {
            var quantity = context.InputInt("Введите количество товара");
            var orderedItemDto = new OrderedItemDto {Quantity = quantity, Contract = contractDto, Item = item};
            contractDto.OrderedItems.Add(orderedItemDto);
        } 
    }
}