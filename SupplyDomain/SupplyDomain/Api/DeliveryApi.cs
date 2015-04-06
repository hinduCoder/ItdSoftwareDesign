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

        public virtual List<DeliveryDto> GetAllDeliveries()
        {
            return _deliveryRepository.AsQueryable()
                .Select(DeliveryDto.GetExpression())
                .ToList();
        }

     

        //TODO возвращать список delivery. 
        //TODO В меню -> статусы -> по одному контракту -> по несколько delivery -> выбираем из списка
        public virtual DeliveryDto GetContractDeliveries(Guid contractId)
        {
            return _deliveryRepository.AsQueryable()
                .Select(DeliveryDto.GetExpression())
                .Single(d => d.ContractId == contractId);
        }

        public virtual void AddNewDelivery(Guid contractId)
        {
            var contract = _contractRepository.Get(contractId);
            _deliveryRepository.Add(new Delivery(contract));
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