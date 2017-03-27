using System.Collections.Generic;
using SGR.Domain.Entities;

namespace SGR.Domain.Interfaces.Services
{
    public interface IRestaurantService : IServiceBase<Restaurant>
    {
        List<Restaurant> Search(string term);

    }
}
