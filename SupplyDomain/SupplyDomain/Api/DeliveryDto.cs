using System;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public DeliveryStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompleсtDate { get; set; }
        public DateTime? ShipmetDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}