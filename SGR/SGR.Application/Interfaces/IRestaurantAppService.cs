
using System.Collections.Generic;
using SGR.Domain.Entities;

namespace SGR.Application.Interfaces
{
    public interface IRestaurantAppService : IAppServiceBase<Restaurant>
    {
        List<Restaurant> Search(string term);
    }
}
