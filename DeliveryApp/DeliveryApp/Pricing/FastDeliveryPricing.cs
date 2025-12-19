using System.Linq;
using DeliveryApp.Models;

namespace DeliveryApp.Pricing
{
    public class FastDeliveryPricing : IPricingStrategy
    {
        private decimal deliveryFee;
        public FastDeliveryPricing(decimal fee) => deliveryFee = fee;

        public decimal CalculateTotal(Order order) => order.Dishes.Sum(d => d.Price) + deliveryFee;
    }
}
