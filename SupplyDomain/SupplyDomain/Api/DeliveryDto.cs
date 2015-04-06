using System;
using System.Linq.Expressions;
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

        public static Expression<Func<Delivery, DeliveryDto>> GetExpression() {
            return d => new DeliveryDto {
                Id = d.Id,
                CompleсtDate = d.CompleсtDate,
                ContractId = d.Contract.Id,
                DeliveryDate = d.DeliveryDate,
                ShipmetDate = d.ShipmentDate,
                StartDate = d.StartDate,
                Status = d.Status
            };
        }
    }
}