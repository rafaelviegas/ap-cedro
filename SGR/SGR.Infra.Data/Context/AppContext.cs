
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SGR.Domain.Entities;
using SGR.Infra.Data.EntityConfig;

namespace SGR.Infra.Data.Context
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("SGRContext") { }


        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new RestaurantConfiguration());
            modelBuilder.Configurations.Add(new DishConfiguration());
        }
    }
}
