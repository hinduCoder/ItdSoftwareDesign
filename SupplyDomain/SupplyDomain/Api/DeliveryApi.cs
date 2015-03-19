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

        public void AddNewDelivery(Guid contractId)
        {
            _deliveryRepository.Add(new Delivery(_contractRepository.Get(contractId)));
        }

        public void SetComplectStatus(Guid deliveryId)
        {
            GetDelivery(deliveryId).SetComplextStatus();
        }

        public void SetShipmentStatus(Guid deliveryId)
        {
            GetDelivery(deliveryId).SetShipmentStatus();
        }

        public void SetDeliveryDate(Guid deliveryId)
        {
            GetDelivery(deliveryId).SetDeliveryDate();
        }

        private Delivery GetDelivery(Guid deliveryId)
        {
            return _deliveryRepository.Get(deliveryId);
        }
    }
}