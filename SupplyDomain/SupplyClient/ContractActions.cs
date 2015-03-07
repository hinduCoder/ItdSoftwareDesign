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
        private IRepository<Contract> _contractsRepository;
        private ItemApi _itemApi; 

        public ContractActions(IRepository<Contract> contractsRepository, ItemApi itemApi)
        {
            _contractsRepository = contractsRepository;
            _itemApi = itemApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var contractStartDate = context.InputDateTime("Введите дату начала действия договора");
            var contract = new Contract(contractStartDate);
            ChooseItemsForContract(context, contract);
            _contractsRepository.Add(contract);
        }


        public void ChooseItemsForContract(ActionExecutionContext context, Contract contract)
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

        public void AddNewOrderedItem(ActionExecutionContext context, ItemDto item, Contract contract)
        {
            var quantity = context.InputInt("Введите количество товара");
            var orderedItem = new OrderedItem(quantity, item);
            contract.AddOrderedItem(orderedItem);
        } 
    }
}