using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGR.Models.Dish
{
    public class DishEditViewModel
    {
        public int DishId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}