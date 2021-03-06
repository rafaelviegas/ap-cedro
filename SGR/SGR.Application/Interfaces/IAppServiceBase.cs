﻿using System.Linq;

namespace SGR.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> Get();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}

