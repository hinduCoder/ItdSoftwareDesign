using System.Collections.Generic;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractInput
    {
        public Period Period { get; set; }
        public string Number { get; set; }
        public List<OrderedItemInput> OrderedItems { get; private set; }
        public string Participant { get; set; }
     
        public ContractInput()
        {
            OrderedItems = new List<OrderedItemInput>();
        }
    }
}