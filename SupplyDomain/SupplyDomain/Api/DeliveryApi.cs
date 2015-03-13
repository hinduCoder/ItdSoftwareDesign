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
                    ContractDto = ContractDto.FromContract(d.Contract),
                    DeliveryDate = d.DeliveryDate,
                    ShipmetDate = d.ShipmetDate,
                    StartDate = d.StartDate,
                    Status = d.Status
                }).ToList();
        }

        public void AddNewDelivery(ContractDto contractDto)
        {
            _deliveryRepository.Add(new Delivery(_contractRepository
                .AsQueryable()
                .Single(c => contractDto.Id == c.Id )));
        }

        public void SetStatus(DeliveryDto deliveryDto, DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.Complext: 
                    SetComplextStatus(deliveryDto);
                    break;
                case DeliveryStatus.Shipment: 
                    SetShipmentStatus(deliveryDto);
                    break;
                case DeliveryStatus.Delivery: 
                    SetDeliveryDate(deliveryDto); 
                    break;
                default: 
                    throw new ArgumentException(String.Format("It's impossible to change status to {0}", status));
            }
        }

        public void SetComplextStatus(DeliveryDto deliveryDto)
        {
            GetDelivery(deliveryDto).SetComplextStatus();
        }

        public void SetShipmentStatus(DeliveryDto deliveryDto)
        {
            GetDelivery(deliveryDto).SetShipmentStatus();
        }

        public void SetDeliveryDate(DeliveryDto deliveryDto)
        {
            GetDelivery(deliveryDto).SetDeliveryDate();
        }

        private Delivery GetDelivery(DeliveryDto deliveryDto)
        {
            return _deliveryRepository.AsQueryable().Single(d => d.Id == deliveryDto.Id);
        }
    }
}