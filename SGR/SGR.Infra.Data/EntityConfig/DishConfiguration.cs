
using System.Data.Entity.ModelConfiguration;
using SGR.Domain.Entities;

namespace SGR.Infra.Data.EntityConfig
{
    public class DishConfiguration: EntityTypeConfiguration<Dish>
    {
        public DishConfiguration()
        {
            HasKey(x => x.DishId);
        }
    }
}
