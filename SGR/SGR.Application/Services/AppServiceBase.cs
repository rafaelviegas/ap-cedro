using System;
using System.Linq;
using SGR.Application.Interfaces;
using SGR.Domain.Interfaces.Services;

namespace SGR.Application.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);

        }

        public IQueryable<TEntity> Get()
        {
            return _serviceBase.Get();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        void IAppServiceBase<TEntity>.Dispose()
        {
            _serviceBase.Dispose();
        }

        void IDisposable.Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
