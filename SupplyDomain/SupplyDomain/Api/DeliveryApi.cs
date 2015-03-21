using System;
using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class DeliveryApi
    {
        private IRepository<Delivery> _deliveryRepository;
        private IRepository<Contract> _contractRepository;

        public DeliveryApi(IRepository<Delivery> deliveryRepository, IRepository<Contract> contractRepository)
        {
            _deliveryRepository = deliveryRepository;
            _contractRepository = contractRepository;
        }

        public List<DeliveryDto> GetAllDeliveries()
        {
            return _deliveryRepository.AsQueryable()
                .Select(d => new DeliveryDto
                {
                    Id = d.Id,
                    ComplextDate = d.ComplextDate,
                    ContractId = d.Contract.Id,
                    DeliveryDate = d.DeliveryDate,
                    ShipmetDate = d.ShipmentDate,
                    StartDate = d.StartDate,
                    Status = d.Status
                })
                .ToList();
        }

        public DeliveryDto GetDeliveryWithContract(Guid contractId)
        {
            return _deliveryRepository.AsQueryable().Select(d => new DeliveryDto {
                Id = d.Id,
                ComplextDate = d.ComplextDate,
                ContractId = d.Contract.Id,
                DeliveryDate = d.DeliveryDate,
                ShipmetDate = d.ShipmentDate,
                StartDate = d.StartDate,
                Status = d.Status
            }).Single(d => d.ContractId == contractId);
        }
        public void AddNewDelivery(Guid contractId)
        {
            _deliveryRepository.Add(new Delivery(_contractRepository.Get(contractId)));
        }

        public void Complect(Guid deliveryId)
        {
            GetDelivery(deliveryId).Complect();
        }

        public void Ship(Guid deliveryId)
        {
            GetDelivery(deliveryId).Ship();
        }

        public void Deliver(Guid deliveryId)
        {
            GetDelivery(deliveryId).Deliver();
        }

        private Delivery GetDelivery(Guid deliveryId)
        {
            return _deliveryRepository.Get(deliveryId);
        }
    }
}