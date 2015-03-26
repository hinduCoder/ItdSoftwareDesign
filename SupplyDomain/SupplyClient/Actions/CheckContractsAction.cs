using System;
using Feonufry.CUI.Actions;
using SupplyDomain.Api;

namespace SupplyClient.Actions
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
            var contracts = _contractApi.ActivateContractsByDueDate(date);
            foreach (var contractDto in contracts)
            {
                context.Out.WriteLine(contractDto.ConvertToString());
            }
        }
    }
}