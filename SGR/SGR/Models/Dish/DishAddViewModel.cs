

namespace SGR.Models.Dish
{
    public class DishAddViewModel
    {
        public int DishId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}