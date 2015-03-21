using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain;
using SupplyDomain.Api;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyClient
{
    public class StatusesAction : IAction
    {
        private ContractApi _contractApi;
        private DeliveryApi _deliveryApi;

        public StatusesAction(ContractApi contractApi, DeliveryApi deliveryApi)
        {
            _contractApi = contractApi;
            _deliveryApi = deliveryApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            ChooseContract(context);
        }

        public void ChooseContract(ActionExecutionContext context)
        {
            var itemsSubMenu = new MenuBuilder().Repeatable().Title("Выберите контракт");
            var contracts = _contractApi.GetActiveContracts();
            foreach (var contractDto in contracts)
            {
                var contractDtoCaptured = contractDto;
                itemsSubMenu.Item().Title(ConvertContractToBriefString(contractDto)).Action(ctx => ChangeStatus(ctx, contractDtoCaptured));
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void ChangeStatus(ActionExecutionContext context, ContractDto contractDto)
        {
            context.Out.WriteLine(ConvertContractDtoToString(contractDto));
            var deliveryDto = _deliveryApi.GetDeliveryWithContract(contractDto.Id);
            context.Out.WriteLine("Cтатус: {0}", ConvertStatusToString(deliveryDto.Status));

            new MenuBuilder().RunnableOnce()
                .Item("Укомплектовать", ctx => _deliveryApi.Complect(deliveryDto.Id))
                .Item("Отправить", ctx => _deliveryApi.Ship(deliveryDto.Id))
                .Item("Отгрузить", ctx => _deliveryApi.Deliver(deliveryDto.Id))
                .Exit("Отмена").GetMenu().Run();

        }

        private string ConvertStatusToString(DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.Started:
                    return "Открыт";
                case DeliveryStatus.Complect:
                    return "Укомлектована";
                case DeliveryStatus.Shipment:
                    return "Отправлена";
                case DeliveryStatus.Delivery:
                    return "Доставлена";
            }
            return String.Empty;
        }
        private string ConvertContractToBriefString(ContractDto contractDto)
        {
            return String.Format("{0} {1}", contractDto.Number, contractDto.Participant);
        }
        
        private string ConvertContractDtoToString(ContractDto contractDto) {
            return String.Format("Номер: {0}\nДата начала действия: {1:D}\nПериодичность: {2}\nДата окончания действия: {3:D}",
               contractDto.Number, contractDto.Period.StartDate, contractDto.Period.MonthRepetition, contractDto.Period.CloseDate);
        }
    }
}