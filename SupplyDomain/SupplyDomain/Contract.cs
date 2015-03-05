using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class Contract
    {
        private string _number;
        private DateTime _startDate;
        private List<string> _participants;
        private Period _period;
        private OrderedItem _orderedItem;
        private DeliveryItem _deliveryItem;

        public Contract(string number, DateTime startDate, List<string> participants, Period period, OrderedItem orderedItem, DeliveryItem deliveryItem)
        {
            _number = number;
            _startDate = startDate;
            _participants = participants;
            _period = period;
            _orderedItem = orderedItem;
            _deliveryItem = deliveryItem;
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
