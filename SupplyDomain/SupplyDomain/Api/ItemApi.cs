using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class ItemApi
    {
        private readonly IRepository<Item> _itemsRepository;

        public ItemApi(IRepository<Item> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public List<ItemDto> GetAllItems()
        {
            return _itemsRepository.AsQueryable()
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .ToList();
        }
    }
}