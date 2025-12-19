using DeliveryApp.Pricing;

namespace DeliveryApp.Models
{
    public class OrderBuilder
    {
        private Order order = new Order();

        public OrderBuilder AddDish(Dish dish)
        {
            order.Dishes.Add(dish);
            return this;
        }

        public OrderBuilder SetPricing(IPricingStrategy strategy)
        {
            order.PricingStrategy = strategy;
            return this;
        }

        public Order Build() => order;
    }
}
