using System.Collections.Generic;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractDto
    {
        public ContractDto()
        {
            OrderedItems = new List<OrderedItemDto>();
        }

        public ContractDto(string number, Period period)
            :this()
        {
            Number = number;
            Period = period;
        }

        public Period Period { get; set; }
        public string Number { get; set; }
        public List<OrderedItemDto> OrderedItems { get; private set; }
    }
}