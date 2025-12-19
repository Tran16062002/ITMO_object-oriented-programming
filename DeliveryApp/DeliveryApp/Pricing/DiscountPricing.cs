using System.Linq;
using DeliveryApp.Models;

namespace DeliveryApp.Pricing
{
    public class DiscountPricing : IPricingStrategy
    {
        private decimal discountPercentage;
        public DiscountPricing(decimal discountPercentage) => this.discountPercentage = discountPercentage;

        public decimal CalculateTotal(Order order)
        {
            decimal total = order.Dishes.Sum(d => d.Price);
            return total * (1 - discountPercentage / 100);
        }
    }
}
