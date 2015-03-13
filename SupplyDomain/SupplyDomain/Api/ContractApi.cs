using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractApi
    {
        private readonly IRepository<Contract> _contractsRepository;
        private readonly IRepository<OrderedItem> _orderedItemRepository;

        public ContractApi(IRepository<Contract> contractsRepository, IRepository<OrderedItem> orderedItemRepository)
        {
            _contractsRepository = contractsRepository;
            _orderedItemRepository = orderedItemRepository;
        }

        public List<ContractDto> GetAllContracts()
        {
            return _contractsRepository.AsQueryable()
                .Select(c => new ContractDto(c.Number, c.Period) {Id = c.Id}).ToList();
        }

        public void AddNewContract(ContractDto contractDto)
        {
            var contract = new Contract(contractDto.Number, contractDto.Period);
            foreach (var orderedItemDto in contractDto.OrderedItems)
            {
                contract.AddOrderedItem(_orderedItemRepository
                    .AsQueryable()
                    .Single(o => o.Id == orderedItemDto.Id));
            }
            _contractsRepository.Add(contract);
        }
    }
}