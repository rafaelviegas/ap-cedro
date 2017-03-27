
namespace SGR.Domain.Entities
{
    public class Dish
    {
        public int DishId { get;  set; }
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public virtual Restaurant Restaurant { get; set; }

        protected Dish(){}

        public Dish(string name, decimal price, int restaurantId )
        {
            this.Name = name;
            this.Price = price;
            this.RestaurantId = restaurantId;
        }

        public Dish ChangeName(string name)
        {
            this.Name = name;
            return this;
        }

        public Dish ChangePrice(decimal price)
        {
            this.Price = price;
            return this;
        }

        public Dish ChangeRestaurant(int restaurantId)
        {
            this.RestaurantId = restaurantId;
            return this;
        }

    }
}
