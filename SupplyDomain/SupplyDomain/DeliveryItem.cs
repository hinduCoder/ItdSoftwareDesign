using System;

namespace SupplyDomain
{
    public enum DeliveryStatus
    {
        Expected, 
        Performed,
        Completed 
    }

    public class DeliveryItem
    {
        private DeliveryStatus _status;
        private DateTime _date;

        public DeliveryItem(DateTime data)
        {
            _date = data;
            _status = DeliveryStatus.Expected;
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public DeliveryStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public void SetPerformed()
        {
            _date = DateTime.Now;
            _status = DeliveryStatus.Performed;
        }

        public void SetCompleted()
        {
            _date = DateTime.Now;
            _status = DeliveryStatus.Completed;
        }
    }
}
