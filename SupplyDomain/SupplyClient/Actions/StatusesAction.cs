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
        //todo:получать delivery
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
        //TODO: выводить только изменения статусов которые можно сделать
        public void ChangeStatus(ActionExecutionContext context, ContractDto contractDto)
        {
            context.Out.WriteLine(contractDto.ConvertToString());
            var deliveryDto = _deliveryApi.GetContractDeliveries(contractDto.Id);
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
    }
}