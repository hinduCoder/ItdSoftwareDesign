using System;
using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ContractApi
    {
        private readonly IRepository<Contract > _contractsRepository;
        private readonly IRepository<OrderedItem> _orderedItemsRepository;
        private readonly IRepository<Item> _itemsRepository;
        private readonly IRepository<Delivery> _deliveriesRepository; 

        public ContractApi(IRepository<Contract> contractsRepository, IRepository<OrderedItem> orderedItemsRepository, IRepository<Item> itemsRepository, IRepository<Delivery> deliveriesRepository)
        {
            _contractsRepository = contractsRepository;
            _orderedItemsRepository = orderedItemsRepository;
            _itemsRepository = itemsRepository;
            _deliveriesRepository = deliveriesRepository;
        }

        public virtual List<ContractDto> GetAllContracts()
        {
            return _contractsRepository.AsQueryable()
                .Select(ContractDto.GetExpression())
                .ToList();
        }

        public virtual void AddNewContract(ContractInput contractInput)
        {
            var contract = new Contract(contractInput.Number, contractInput.Period, contractInput.Participant);
            _contractsRepository.Add(contract);

            foreach (var orderedItemDto in contractInput.OrderedItems)
            {
                var item = _itemsRepository.Get(orderedItemDto.ItemId);
                var orderedItem = new OrderedItem(orderedItemDto.Quantity, item);
                _orderedItemsRepository.Add(orderedItem);
            }
        }

        public virtual List<ContractDto> GetActiveContracts()
        {
            // TODO: обойтись без join
            return _contractsRepository.AsQueryable()
                .Join(_deliveriesRepository.AsQueryable(), c => c.Id, d => d.Contract.Id, (c, d) => c)
                .Select(ContractDto.GetExpression())
                .ToList();
        }

        public virtual List<ContractDto> GetArchiveContracts(DateTime date)
        {
            return _contractsRepository.AsQueryable()
                .Where(c => c.Period.CloseDate < date)
                .Select(ContractDto.GetExpression())
                .ToList();
        }

        public virtual List<ContractDto> ActivateContractsByDueDate(DateTime date)
        {
            var contracts = GetContractsByDueDate(date);
            foreach (var contract in contracts)
            {
                _deliveriesRepository.Add(new Delivery(contract)); 
            }

            return contracts
                .Select(
                    c => new ContractDto {Number = c.Number, Period = c.Period, Id = c.Id, Participant = c.Participant})
                .ToList();

        }

        private List<Contract> GetContractsByDueDate(DateTime dueDate) {
            return _contractsRepository
                .AsQueryable()
                .Where(contract => dueDate >= contract.Period.StartDate && dueDate < contract.Period.CloseDate)
                .ToList()
                .Where(contract => contract.Period.IsDueDate(dueDate))
                .ToList();
        }
    }
}