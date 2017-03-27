using SGR.Domain.Entities;
using SGR.Domain.Interfaces.Repositories;
using SGR.Domain.Interfaces.Services;

namespace SGR.Domain.Services
{
    public class DishService: ServiceBase<Dish>, IDishService
    {
        private readonly IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
            :base(dishRepository)
        {
            _dishRepository = dishRepository;
        }
    }
}
