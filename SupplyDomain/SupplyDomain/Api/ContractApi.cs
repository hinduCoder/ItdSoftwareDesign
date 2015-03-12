using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractApi
    {
        private readonly IRepository<Contract> _contractsRepository;

        public ContractApi(IRepository<Contract> contractsRepository)
        {
            _contractsRepository = contractsRepository;
        }

        public List<ContractDto> GetAllContracts()
        {
            return _contractsRepository.AsQueryable()
                .Select(c => new ContractDto(c.Number, c.Period)).ToList();
        }

        public void AddNewContract(ContractDto contractDto)
        {
            var contract = new Contract(contractDto.Number, contractDto.Period);
            foreach (var orderedItemDto in contractDto.OrderedItems)
            {
                //TODO мощный эй пи ай добавления ордеред айтемов
                //contract.AddOrderedItem(new OrderedItem(contract, orderedItemDto.Quantity, new Item()));
            }
            _contractsRepository.Add(contract);
        }
    }
}