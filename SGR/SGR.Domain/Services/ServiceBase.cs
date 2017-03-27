using System;
using System.Linq;
using System.Linq.Expressions;
using SGR.Domain.Interfaces.Repositories;
using SGR.Domain.Interfaces.Services;

namespace SGR.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Get(filter, includes);
        }

        public IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
