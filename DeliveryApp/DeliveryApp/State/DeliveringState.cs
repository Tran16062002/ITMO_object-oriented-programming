using DeliveryApp.Models;

namespace DeliveryApp.State
{
    public class DeliveringState : IOrderState
    {
        public void Next(Order order) => order.SetState(new CompletedState());
        public string GetStatus() => "Доставка";
    }
}
