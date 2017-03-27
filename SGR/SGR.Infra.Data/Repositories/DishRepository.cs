using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Repositories;
using SGR.Infra.Data.Context;

namespace SGR.Infra.Data.Repositories
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        private readonly AppContext _appContext;
        public DishRepository(AppContext appContext)
            : base(appContext)
        {
            _appContext = appContext;
        }
    }
}
