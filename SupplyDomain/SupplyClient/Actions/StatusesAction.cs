using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using SupplyDomain.Api;
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
            ChooseDelivery(context);
        }
        //TODO: DONE получать delivery вместо контрактов
        //TODO: DONE выводить только изменения статусов которые можно сделать
        public void ChooseDelivery(ActionExecutionContext context)
        {
            var itemsSubMenu = new MenuBuilder().Repeatable().Title("Выберите доставку по выбранному контракту");
            var deliveryDtos = _deliveryApi.GetNotClosedDeliveries();
            foreach (var deliveryDto in deliveryDtos)
            {
                var deliveryDtoCaptured = deliveryDto;
                itemsSubMenu.Item(ConvertDeliveryToString(deliveryDto), ctx => ChangeStatus(ctx, deliveryDtoCaptured));
            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void ChangeStatus(ActionExecutionContext context, DeliveryDto deliveryDto)
        {
            context.Out.WriteLine("Cтатус: {0}", ConvertStatusToString(deliveryDto.Status));

            new MenuBuilder().RunnableOnce()
                .Item().Title("Укомплектовать").Action(ctx => _deliveryApi.Complect(deliveryDto.Id))
                    .AvailableWhen(() => deliveryDto.CanComplect).End()
                .Item().Title("Отправить").Action(ctx => _deliveryApi.Ship(deliveryDto.Id))
                    .AvailableWhen(() => deliveryDto.CanShip).End()
                .Item().Title("Отгрузить").Action(ctx => _deliveryApi.Deliver(deliveryDto.Id))
                    .AvailableWhen(() => deliveryDto.CanDeliver).End()
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

        private string ConvertDeliveryToString(DeliveryDto deliveryDto)
        {
            return String.Format("Контракт {0}. Дата поставки {1:D}", deliveryDto.ContractNumber, deliveryDto.StartDate);
        }

        private string ConvertContractToBriefString(ContractDto contractDto)
        {
            return String.Format("{0} {1}", contractDto.Number, contractDto.Participant);
        }
    }
}