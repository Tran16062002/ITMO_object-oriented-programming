using DeliveryApp.Models;
using DeliveryApp.Pricing;

namespace DeliveryApp.Factories
{
    public class FastDeliveryOrderFactory : IOrderFactory
    {
        public Order CreateOrder() => new OrderBuilder().SetPricing(new FastDeliveryPricing(50)).Build();
    }
}
