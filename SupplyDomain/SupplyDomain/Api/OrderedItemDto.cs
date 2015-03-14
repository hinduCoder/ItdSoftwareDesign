using System;

namespace SupplyDomain.Api
{
    public class OrderedItemDto
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid ContractId { get; set; }
        public int Quantity { get; set; }
    }
}