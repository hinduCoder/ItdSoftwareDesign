using System;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Period Period { get; set; }
        public string Number { get; set; }
        public string Participant { get; set; }
    }
}