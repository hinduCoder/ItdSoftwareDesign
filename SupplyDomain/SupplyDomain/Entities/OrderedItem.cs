namespace SupplyDomain.Entities
{
    public class OrderedItem : Entity
    {
        private Contract _contract;
        private int _quantity;
        private Item _item;

        public int Quantity
        {
            get { return _quantity; }
        }

        public Item Item
        {
            get { return _item; }
        }

        public OrderedItem(Contract contract, int quantity, Item item)
        {
            _quantity = quantity;
            _item = item;
            _contract = contract;
        }
    }
}
