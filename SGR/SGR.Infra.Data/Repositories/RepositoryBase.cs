using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SGR.Domain.Interfaces.Repositories;
using SGR.Infra.Data.Context;

namespace SGR.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppContext _ctx;

        public RepositoryBase(AppContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(TEntity obj)
        {
            _ctx.Set<TEntity>().Add(obj);
            _ctx.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _ctx.Entry(obj).State = EntityState.Modified;
            _ctx.SaveChanges();

        }

        public void Remove(TEntity obj)
        {
            _ctx.Set<TEntity>().Remove(obj);
            _ctx.SaveChanges();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes)
        {

            return filter == null ? includes.Aggregate(_ctx.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include)) : includes.Aggregate(_ctx.Set<TEntity>().Where(filter), (current, include) => current.Include(include));

        }

        public IQueryable<TEntity> Get()
        {
            return _ctx.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
