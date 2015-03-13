using System;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Article { get; set; }

        internal Item ToItem()
        {
            return new Item(Name, Description, Article);
        }
    }
}