﻿using System;
using System.Collections.Generic;
using System.Linq;
using SupplyDomain.Entities;

namespace SupplyDomain.DataAccess
{
    public class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _list = new List<T>();

        public T Get(Guid id)
        {
            return _list.FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            _list.Add(entity);
        }

        public void Remove(T entity)
        {
            _list.Remove(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return _list.AsQueryable();
        }
    }
}