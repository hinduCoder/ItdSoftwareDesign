using System.Net.Mime;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;

namespace SupplyClient
{
    public class ContractActions : IAction
    {
        private IRepository<Contract> _contractsRepository;
        private IRepository<Item> _itemRepository; 

        public ContractActions(IRepository<Contract> contractsRepository, IRepository<Item> itemRepository)
        {
            _contractsRepository = contractsRepository;
            _itemRepository = itemRepository;
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
            foreach (var item in _itemRepository.AsQueryable())
            {
                itemsSubMenu.Item().AlwaysAvailable().Title(item.Name).Action(ctx => { AddNewOrderedItem(ctx, item, contract); });
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
            
        }

        public void AddNewOrderedItem(ActionExecutionContext context, Item item, Contract contract)
        {
            var quantity = context.InputInt("Введите количество товара");
            var orderedItem = new OrderedItem(quantity, item);
            contract.AddOrderedItem(orderedItem);
        } 
    }
}