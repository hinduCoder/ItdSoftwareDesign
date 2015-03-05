using System;
using System.Collections.Generic;

namespace SupplyDomain
{
    public class ContractRepository : IRepository<Contract>
    {
        private List<Contract> contracts = new List<Contract>(); 

        public void Add(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException();
            }
            contracts.Add(contract);
        }

        public void Delete(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException();
            }
            contracts.Remove(contract);
        }

        public Contract FindByNumber(String number)
        {
            foreach (var contract in contracts)
            {
                if (contract.Number.Equals(number))
                {
                    return contract;
                }
            }
        }
    }
}