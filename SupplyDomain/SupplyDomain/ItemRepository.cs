using System;
using System.Collections.Generic;

namespace SupplyDomain
{
    public class ItemRepository : IRepository
    {
        private List<Item> items = new List<Item>();

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();
            items.Add(item);
        }

        public void Delete(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();
            items.Remove(item);
        }

        public Item FindByArticle(string article)
        {
            foreach (var item in items)
            {
                if (item.Article.Equals(article))
                {
                    return item;
                }
            }
        }
    }
}