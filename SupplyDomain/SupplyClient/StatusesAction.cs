using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyClient
{
    public class StatusesAction : IAction
    {
        private IRepository<Contract> _contractsRepository;

        public StatusesAction(IRepository<Contract> contractsRepository)
        {
            _contractsRepository = contractsRepository;
        }

        public void Perform(ActionExecutionContext context)
        {
            ChooseContract(context);
        }

        public void ChooseContract(ActionExecutionContext context)
        {
            var itemsSubMenu = new MenuBuilder().Repeatable().Title("Выберите контракт");
            foreach (var contract in _contractsRepository.AsQueryable())
            {
                itemsSubMenu.Item().AlwaysAvailable().Title(contract.ToString()).Action(ctx => { ChangeStatus(ctx, contract); });
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void ChangeStatus(ActionExecutionContext context, Contract contract)
        {
            //context.Out.WriteLine((contract.Delivery.StartDate.Status+1).ToString());
        }
    }
}