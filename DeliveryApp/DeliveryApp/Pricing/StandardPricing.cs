using System.Linq;
using DeliveryApp.Models;

namespace DeliveryApp.Pricing
{
    public class StandardPricing : IPricingStrategy
    {
        public decimal CalculateTotal(Order order) => order.Dishes.Sum(d => d.Price);
    }
}
