namespace SupplyDomain
{
    public class DemoDataGenerator
    {
        private readonly IRepository<Item> _itemsRepository;
        private readonly IRepository<Period> _periodsRepository;

        public DemoDataGenerator(IRepository<Item> itemsRepository, IRepository<Period> periodsRepository)
        {
            _itemsRepository = itemsRepository;
            _periodsRepository = periodsRepository;
        }

        public void Generate()
        {
            _itemsRepository.Add(new Item("Картошка", "Овощи", "П-1-1-1"));
        }
    }
}