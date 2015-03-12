using System;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class DeliveryDto
    {
        public Contract Contract { get; set; }
        public DeliveryStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ComplextDate { get; set; }
        public DateTime? ShipmetDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}