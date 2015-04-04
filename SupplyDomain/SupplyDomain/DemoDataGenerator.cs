using System;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain
{
    public class DemoDataGenerator
    {
        private readonly IRepository<Item> _itemsRepository;
        private readonly IRepository<Contract> _contractRepository; 

        public DemoDataGenerator(IRepository<Item> itemsRepository, IRepository<Contract> contractRepository)
        {
            _itemsRepository = itemsRepository;
            _contractRepository = contractRepository;
        }

        public void Generate()
        {
            GenerateItems();
            GenerateContracts();
        }

        private void GenerateContracts()
        {
            Contract contract;
            OrderedItem orderedItem;
            var items = _itemsRepository.AsQueryable().ToList();

            contract = new Contract("123456789asdf", 
                new Period(DateTime.Parse("10.03.2014"), 1, DateTime.Parse("10.03.2016")), "Макфа");
            orderedItem = new OrderedItem(2, items[0]);
            contract.AddOrderedItem(orderedItem);
            _contractRepository.Add(contract);

            contract = new Contract("fdsa987654321",
                new Period(DateTime.Parse("25.06.2012"), 2, DateTime.Parse("25.06.2017")), "Такиесптичкино");
            orderedItem = new OrderedItem(1, items[0]);
            contract.AddOrderedItem(orderedItem);
            orderedItem = new OrderedItem(1, items[1]);
            contract.AddOrderedItem(orderedItem);
            _contractRepository.Add(contract);
        }

        private void GenerateItems()
        {
            _itemsRepository.Add(new Item("Картошка", "Овощи", "П-1-1-1"));
            _itemsRepository.Add(new Item("Макароны", "Макаронные изделия", "П-2-43-142"));
        }
    }
}