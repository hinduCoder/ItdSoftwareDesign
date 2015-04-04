using System;
using System.Collections.Generic;

namespace SupplyDomain.Entities
{
    public class Contract : Entity
    {
        private Period _period;
        private readonly IList<OrderedItem> _orderedItems = new List<OrderedItem>();
        private readonly string _participant;
        private readonly string _number;

        public Contract(string number, Period period, string participant)
        {
            _number = number;
            _period = period;
            _participant = participant;
        }

        public void AddOrderedItem(OrderedItem orderedItem)
        {
            _orderedItems.Add(orderedItem);
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", Id, _period.StartDate);
        }

        public string Number
        {
            get { return _number; }
        }

        public Period Period
        {
            get { return _period; }
        }

        public string Participant
        {
            get { return _participant; }
        }
    }
}
