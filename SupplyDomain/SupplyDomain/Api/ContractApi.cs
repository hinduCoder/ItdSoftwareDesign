using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractApi
    {
        private readonly IRepository<Contract> _contractsRepository;
        private readonly IRepository<OrderedItem> _orderedItemsRepository;
        private readonly IRepository<Item> _itemsRepository;

        public ContractApi(IRepository<Contract> contractsRepository, IRepository<OrderedItem> orderedItemsRepository, IRepository<Item> itemsRepository)
        {
            _contractsRepository = contractsRepository;
            _orderedItemsRepository = orderedItemsRepository;
            _itemsRepository = itemsRepository;
        }

        public List<ContractDto> GetAllContracts()
        {
            return _contractsRepository.AsQueryable()
                .Select(c => new ContractDto{ Number = c.Number, Period = c.Period, Id = c.Id, Participant = c.Participant}).ToList();
        }

        public void AddNewContract(ContractInput contractInput)
        {
            var contract = new Contract(contractInput.Number, contractInput.Period, contractInput.Participant);
            foreach (var orderedItemDto in contractInput.OrderedItems)
            {
                var item = _itemsRepository.Get(orderedItemDto.ItemId);
                var orderedItem = new OrderedItem(contract, orderedItemDto.Quantity, item);
                _orderedItemsRepository.Add(orderedItem);
            }
            _contractsRepository.Add(contract);
        }
    }
}