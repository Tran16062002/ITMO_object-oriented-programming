using System.Collections.Generic;

namespace DeliveryApp.Models
{
    public class Menu
    {
        private List<Dish> dishes = new List<Dish>();

        public void AddDish(Dish dish) => dishes.Add(dish);
        public IReadOnlyList<Dish> GetDishes() => dishes.AsReadOnly();
    }
}
