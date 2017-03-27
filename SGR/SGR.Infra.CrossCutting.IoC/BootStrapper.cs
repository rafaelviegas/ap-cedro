using SGR.Application.Interfaces;
using SGR.Application.Services;
using SGR.Domain.Interfaces.Repositories;
using SGR.Domain.Interfaces.Services;
using SGR.Domain.Services;
using SGR.Infra.Data.Context;
using SGR.Infra.Data.Repositories;
using SimpleInjector;

namespace SGR.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<AppContext>(Lifestyle.Scoped);

            container.Register<IRestaurantAppService, RestaurantAppService>(Lifestyle.Scoped);
            container.Register<IDishAppService, DishAppService>(Lifestyle.Scoped);

            container.Register<IRestaurantService, RestaurantService>(Lifestyle.Scoped);
            container.Register<IDishService, DishService>(Lifestyle.Scoped);

            container.Register<IRestaurantRepository, RestaurantRepository>(Lifestyle.Scoped);
            container.Register<IDishRepository, DishRepository>(Lifestyle.Scoped);
        }

    }
}
