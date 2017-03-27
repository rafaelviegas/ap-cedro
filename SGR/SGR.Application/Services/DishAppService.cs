
using SGR.Application.Interfaces;
using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Services;

namespace SGR.Application.Services
{
    public class DishAppService : AppServiceBase<Dish>, IDishAppService
    {
        private readonly IDishService _dishService;
        public DishAppService(IDishService dishService)
            :base(dishService)
        {
            _dishService = dishService;
        }
    }
}
