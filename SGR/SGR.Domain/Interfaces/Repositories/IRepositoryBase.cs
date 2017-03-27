using System;
using System.Linq;
using System.Linq.Expressions;

namespace SGR.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Get();

        TEntity GetById(int id);

        void Dispose();

    }
}
