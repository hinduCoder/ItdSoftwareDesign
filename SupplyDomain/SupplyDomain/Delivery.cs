using System;

namespace SupplyDomain
{
    public class Delivery : Entity
    {
        private DeliveryItem _startDate;
        private DeliveryItem _complextDate;
        private DeliveryItem _shipmetDate;
        private DeliveryItem _deliveryDate;

        public Delivery(DateTime contractDate)
        {
            _startDate = new DeliveryItem(DateTime.Now);
            _complextDate = new DeliveryItem(DateTime.Now);
            _shipmetDate = new DeliveryItem(DateTime.Now);
            _deliveryDate = new DeliveryItem(contractDate);
        }

        public DeliveryItem StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DeliveryItem ComplextDate
        {
            get { return _complextDate; }
            set { _complextDate = value; }
        }

        public DeliveryItem ShipmetDate
        {
            get { return _shipmetDate; }
            set { _shipmetDate = value; }
        }

        public DeliveryItem DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }
    }
}