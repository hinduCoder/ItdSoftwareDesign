using System;

namespace SupplyDomain.Api
{
    public class OrderedItemDto
    {
        public Guid Id { get; set; }
        public ItemDto Item { get; set; }
        public ContractDto Contract { get; set; }
        public int Quantity { get; set; }
    }
}