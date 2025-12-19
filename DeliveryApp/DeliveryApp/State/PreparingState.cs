using DeliveryApp.Models;

namespace DeliveryApp.State
{
    public class PreparingState : IOrderState
    {
        public void Next(Order order) => order.SetState(new DeliveringState());
        public string GetStatus() => "Подготовка";
    }
}
