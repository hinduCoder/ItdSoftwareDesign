using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain
{
    public class DemoDataGenerator
    {
        private readonly IRepository<Item> _itemsRepository;

        public DemoDataGenerator(IRepository<Item> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public void Generate()
        {
            _itemsRepository.Add(new Item("Картошка", "Овощи", "П-1-1-1"));
            _itemsRepository.Add(new Item("Макароны", "Макаронные изделия", "П-2-43-142"));
        }
    }
}