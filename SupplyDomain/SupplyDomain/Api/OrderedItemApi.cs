using System.Collections.Generic;
using System.Linq;
using SupplyDomain.DataAccess;
using SupplyDomain.Entities;

namespace SupplyDomain.Api
{
    public class OrderedItemApi
    {
        private IRepository<OrderedItem> _orederedItemRepository;

        public OrderedItemApi(IRepository<OrderedItem> orederedItemRepository)
        {
            _orederedItemRepository = orederedItemRepository;
        }

        public List<OrderedItemDto> GetAllContracts()
        {
            return _orederedItemRepository.AsQueryable()
                .Select(c => new OrderedItemDto()).ToList();
        }
    }
}