using System.Collections.Generic;
using System.Linq;
using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Repositories;
using SGR.Domain.Interfaces.Services;

namespace SGR.Domain.Services
{
    public class RestaurantService : ServiceBase<Restaurant>, IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
            : base(restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> Search(string term)
        {
            return _restaurantRepository.Get().Where(x => x.Name.Contains(term)).ToList();
        }
    }
}
