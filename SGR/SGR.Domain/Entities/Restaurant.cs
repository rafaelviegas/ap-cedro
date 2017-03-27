using System.Collections.Generic;

namespace SGR.Domain.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Dish> Dishes { get; set; }

        protected Restaurant()
        {
            this.Dishes = new HashSet<Dish>();
        }

        public Restaurant(string name)
        {
            this.Name = name;
        }

        public Restaurant ChangeName(string name)
        {
            this.Name = name;

            return this;
        }

    }
}
