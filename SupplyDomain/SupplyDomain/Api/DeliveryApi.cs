using System;
using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class DeliveryApi
    {
        private readonly IRepository<Delivery> _deliveryRepository;
        private readonly IRepository<Contract> _contractRepository;

        public DeliveryApi(IRepository<Delivery> deliveryRepository, IRepository<Contract> contractRepository)
        {
            _deliveryRepository = deliveryRepository;
            _contractRepository = contractRepository;
        }

        public virtual List<DeliveryDto> GetNotClosedDeliveries()
        {
            return _deliveryRepository.AsQueryable()
                .Where(d => d.Status != DeliveryStatus.Delivery)
                .Select(DeliveryDto.GetExpression())
                .ToList();
        }     

        //TODO: DONE возвращать список delivery. 
        //TODO: DONE В меню -> статусы -> по одному контракту -> по несколько delivery -> выбираем из списка
        public virtual List<DeliveryDto> GetContractDeliveries(Guid contractId)
        {
            return _deliveryRepository.AsQueryable()
                .Select(DeliveryDto.GetExpression())
                .Where(d => d.ContractId == contractId)
                .ToList();
        }

        public virtual void Complect(Guid deliveryId)
        {
            GetDelivery(deliveryId).Complect();
        }

        public virtual void Ship(Guid deliveryId)
        {
            GetDelivery(deliveryId).Ship();
        }

        public virtual void Deliver(Guid deliveryId)
        {
            GetDelivery(deliveryId).Deliver();
        }

        private Delivery GetDelivery(Guid deliveryId)
        {
            return _deliveryRepository.Get(deliveryId);
        }
    }
}