using System;

namespace SupplyDomain.Entities
{
    public class Delivery : Entity
    {
        private Contract _contract;
        private DeliveryStatus _status = DeliveryStatus.Started;
        private DateTime _startDate;
        private DateTime? _complectDate;
        private DateTime? _shipmentDate;
        private DateTime? _deliveryDate;

        public bool CanComplect { get; private set; }
        public bool CanShip { get; private set; }
        public bool CanDeliver { get; private set; }


        public Delivery(Contract contract, DateTime date)
        {
            _contract = contract;
            _startDate = date;
            CanComplect = true;
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

        public DateTime? CompleсtDate
        {
            get { return _complectDate; }
        }

        public DateTime? ShipmentDate
        {
            get { return _shipmentDate; }
        }

        public DateTime? DeliveryDate
        {
            get { return _deliveryDate; }
        }

        public void Complect()
        {
            _complectDate = DateTime.Now;
            _status = DeliveryStatus.Complect;
            CanComplect = false;
            CanShip = true;
        }

        public void Ship()
        {
            _shipmentDate = DateTime.Now;
            _status = DeliveryStatus.Shipment;
            CanShip = false;
            CanDeliver = true;
        }

        public void Deliver()
        {
            _deliveryDate = DateTime.Now;
            _status = DeliveryStatus.Delivery;
            CanDeliver = false;
        }
    }
}