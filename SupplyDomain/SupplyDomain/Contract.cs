using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class Contract
    {
        private Guid _number;
        private DateTime _startDate;
        private List<string> _participants;
        private Period _period;
        private OrderedItem _orderedItem;
        private Delivery _delivery;

        public Contract(DateTime startDate, OrderedItem orderedItem)
        {
            _number = Guid.NewGuid();
            _startDate = startDate;
            _orderedItem = orderedItem;
            _delivery = new Delivery(_startDate);
        }

        public void SetPeriod(int monthRepetition)
        {
            _period = new Period(_startDate, monthRepetition);
        }

        public Guid Number
        {
            get { return _number; }
        }
    }
}
