
namespace SGR.Models.Dish
{
    public class DishListViewModel
    {
        public int DishId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string  Restaurant { get; set; }
    }
}