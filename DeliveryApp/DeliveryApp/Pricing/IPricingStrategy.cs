using DeliveryApp.Models;

namespace DeliveryApp.Pricing
{
    public interface IPricingStrategy
    {
        decimal CalculateTotal(Order order);
    }
}
