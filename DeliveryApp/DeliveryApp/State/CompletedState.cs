using DeliveryApp.Models;

namespace DeliveryApp.State
{
    public class CompletedState : IOrderState
    {
        public void Next(Order order) { /* конечное состояние */ }
        public string GetStatus() => "Выполнен";
    }
}
