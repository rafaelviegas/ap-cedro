using System.Collections.Generic;
using SGR.Application.Interfaces;
using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Services;

namespace SGR.Application.Services
{
    public class RestaurantAppService : AppServiceBase<Restaurant>, IRestaurantAppService
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantAppService(IRestaurantService restaurantService)
            : base(restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public List<Restaurant> Search(string term)
        {
           return _restaurantService.Search(term);
        }
    }
}
