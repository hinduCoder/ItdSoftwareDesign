using System.Net.Mime;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;

namespace SupplyClient
{
    public class ContractActions
    {
        public void AddNewContract(ActionExecutionContext context)
        {
            var contractStartDate = context.InputDateTime("Введите дату начала действия договора");
            var itemsSubMenu = new MenuBuilder().RunnableOnce().Title("Выбора товара");
            foreach (var item in collection)
            {
                itemsSubMenu.Item().AlwaysAvailable().Title(item).Action(ctx => { });
            }
            itemsSubMenu.GetMenu().Run();
        }
    }
}