using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    class OrderedItem
    {
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
        }

        public OrderedItem(int _quantity)
        {
            quantity = _quantity;
        }
    }
}
