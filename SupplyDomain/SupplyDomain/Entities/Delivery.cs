using System;
using System.Security.Cryptography;

namespace SupplyDomain.Entities
{
    public enum DeliveryStatus
    {
        Started,
        Complext,
        Shipment,
        Delivery
    }
    public class Delivery : Entity
    {
        private Contract _contract;
        private DeliveryStatus _status = DeliveryStatus.Started;
        private DateTime _startDate; 
        private DateTime? _complextDate;
        private DateTime? _shipmetDate;
        private DateTime? _deliveryDate;

        public Delivery(Contract contract)
        {
            _contract = contract;
            _startDate = DateTime.Now;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public Contract Contract
        {
            get { return _contract; }
        }

        public DeliveryStatus Status
        {
            get { return _status; }
        }

        public DateTime? ComplextDate
        {
            get { return _complextDate; }
        }

        public DateTime? ShipmetDate
        {
            get { return _shipmetDate; }
        }

        public DateTime? DeliveryDate
        {
            get { return _deliveryDate; }
        }

        public void SetComplextStatus()
        {
            _complextDate = DateTime.Now;
            _status = DeliveryStatus.Complext;
        }

        public void SetShipmentStatus()
        {
            _shipmetDate = DateTime.Now;
            _status = DeliveryStatus.Shipment;
        }

        public void SetDeliveryDate()
        {
            _deliveryDate = DateTime.Now;
            _status = DeliveryStatus.Delivery;
        }       
    }
}