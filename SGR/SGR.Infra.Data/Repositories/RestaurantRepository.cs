using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Repositories;
using SGR.Infra.Data.Context;

namespace SGR.Infra.Data.Repositories
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        private readonly AppContext _appContext;
        public RestaurantRepository(AppContext appContext)
            : base(appContext)
        {
            _appContext = appContext;
        }

    }
}
