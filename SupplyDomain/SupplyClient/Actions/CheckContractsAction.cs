using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain.Api;
using SupplyDomain.Entities;

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
            var contracts = _contractApi.GetAllContracts().Where(c => c.Period.IsDueDate(date));
            foreach (var contractDto in contracts)
            {
                _deliveryApi.AddNewDelivery(contractDto.Id);
                context.Out.WriteLine(ConvertContractDtoToString(contractDto));
            }
        }

        private string ConvertContractDtoToString(ContractDto contractDto)
        {
            return String.Format("Number: {0}\nStart Date: {1}\nMonth repetition: {2}\nClose Date: {3}",
               contractDto.Number, contractDto.Period.StartDate, contractDto.Period.MonthRepetition, contractDto.Period.CloseDate);
        }
    }
}