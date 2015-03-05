using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    interface IRepository
    {
        void Add(Item item);
        void Delete(Item item);
        Item FindByArticle(String article);
    }
}
