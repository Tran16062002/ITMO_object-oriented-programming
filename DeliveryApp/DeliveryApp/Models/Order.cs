using System.Collections.Generic;
using System.Linq;
using DeliveryApp.Pricing;
using DeliveryApp.State;

namespace DeliveryApp.Models
{
    public class Order
    {
        public List<Dish> Dishes { get; private set; } = new List<Dish>();
        public IPricingStrategy PricingStrategy { get; set; }
        private IOrderState state;

        public Order() => state = new PreparingState();

        public void SetState(IOrderState newState) => state = newState;
        public void NextState() => state.Next(this);
        public string GetStatus() => state.GetStatus();

        public decimal GetTotal() => PricingStrategy.CalculateTotal(this);
    }
}
