using DeliveryApp.Models;
using DeliveryApp.Pricing;

namespace DeliveryApp.Factories
{
    public class StandardOrderFactory : IOrderFactory
    {
        public Order CreateOrder() => new OrderBuilder().SetPricing(new StandardPricing()).Build();
    }
}
