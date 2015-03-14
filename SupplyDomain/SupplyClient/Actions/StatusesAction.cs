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
            foreach (var contractDto in _contractApi.GetAllContracts())
            {
                ContractDto dto =
                    _deliveryApi.GetAllDeliveries()
                        .Select(d => d.ContractDto)
                        .SingleOrDefault(c => c.Id == contractDto.Id);
                if (dto == null)
                    continue;
                itemsSubMenu.Item().Title(contractDto.ToString()).Action(ctx => ChangeStatus(ctx, dto));

            }
            itemsSubMenu.Exit("Назад")
                .GetMenu().Run();
        }

        public void ChangeStatus(ActionExecutionContext context, ContractDto contractDto)
        {
            context.Out.WriteLine(contractDto.ToString());
            var deliveryDto = _deliveryApi
                .GetAllDeliveries()
                .Single(d => d.ContractDto.Id == contractDto.Id);
            var currentStatus = deliveryDto.Status;
            context.Out.WriteLine("Текущий статус: {0}", currentStatus.ToString());
            var nextStatus = GetNextStatus(currentStatus);
            if (nextStatus != null)
                context.Out.WriteLine("Следующий доступный статус: {0}", nextStatus);
            else
                return;
            new MenuBuilder().RunnableOnce()
                .Item("Изменить статус", _ => _deliveryApi.SetStatus(deliveryDto, nextStatus.Value))
                .Exit("Отмена").GetMenu().Run();

        }

        private DeliveryStatus? GetNextStatus(DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.Started: 
                    return DeliveryStatus.Complect;
                case DeliveryStatus.Complect: 
                    return DeliveryStatus.Shipment;
                case DeliveryStatus.Shipment: 
                    return DeliveryStatus.Delivery;
                default:
                    return null;
            }
        }
    }
}