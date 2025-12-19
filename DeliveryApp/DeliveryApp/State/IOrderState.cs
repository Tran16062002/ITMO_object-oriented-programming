using DeliveryApp.Models;

namespace DeliveryApp.State
{
    public interface IOrderState
    {
        void Next(Order order);
        string GetStatus();
    }
}
