using System;
using System.Linq.Expressions;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Period Period { get; set; }
        public string Number { get; set; }
        public string Participant { get; set; }

        public static Expression<Func<Contract, ContractDto>> GetExpression()
        {
            return contract => new ContractDto { Number = contract.Number, Period = contract.Period, Id = contract.Id, Participant = contract.Participant };
        }
    }
}