using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class Contract : Entity
    {
        private DateTime _startDate;
        private List<string> _participants;
        private Period _period;
        private MemoryRepository<OrderedItem> _orderedItemsRepository = new MemoryRepository<OrderedItem>();
        private Delivery _delivery;

        public Contract(DateTime startDate)
        {
            _startDate = startDate;
            _delivery = new Delivery(_startDate);
        }

        public void SetPeriod(int monthRepetition)
        {
            _period = new Period(_startDate, monthRepetition);
        }

        public Delivery Delivery
        {
            get { return _delivery; }
        }

        public void AddOrderedItem(OrderedItem orderedItem)
        {
            _orderedItemsRepository.Add(orderedItem);
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", Id.ToString(), _startDate);
        }
    }
}
