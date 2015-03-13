using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain.Api;

namespace SupplyClient
{
    public class CheckContractsAction : IAction
    {
        private ContractApi _contractApi;
        private DeliveryApi _deliveryApi;

        public CheckContractsAction(ContractApi contractApi, DeliveryApi deliveryApi)
        {
            _contractApi = contractApi;
            _deliveryApi = deliveryApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            DateTime date = context.InputDateTime("Введите дату проверки");
            var allContracts = _contractApi.GetAllContracts();
            foreach (var contractDto in allContracts)
            {
                if (contractDto.Period.StartDate == date)
                {
                    _deliveryApi.AddNewDelivery(contractDto);
                    context.Out.WriteLine(contractDto.ToString());
                }
            }

        }
    }
}