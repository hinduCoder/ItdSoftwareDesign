using System;

namespace SupplyDomain.Api
{
    public class OrderedItemInput
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; } 
    }
}