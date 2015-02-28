using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    class OrderedItem
    {
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
        }

        public OrderedItem(int quantity)
        {
            _quantity = quantity;
        }
    }
}
