using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class OrderedItem
    {
        private int _quantity;
        private Item _item;

        public int Quantity
        {
            get { return _quantity; }
        }

        public OrderedItem(int quantity, Item item)
        {
            _quantity = quantity;
            _item = item;
        }
    }
}
