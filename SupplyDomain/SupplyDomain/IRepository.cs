using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item);
    }
}
